from collections import deque
import collections
import json
import re
import time
import typing
from datetime import timedelta
from enum import Enum

import bs4
import numpy as np
import pandas as pd
import multiprocessing
from functools import partial

from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.common.exceptions import TimeoutException
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as ec
from selenium.webdriver.support.select import Select
from selenium.webdriver.support.ui import WebDriverWait

from tax import Tax
from translator import Translator
from argparse import ArgumentParser

pd.options.display.max_columns = None
pd.options.display.max_rows = None
pd.options.display.expand_frame_repr = False
pd.options.mode.chained_assignment = None


DELAY = 20
TIME_SLEEP = 1.5
CARS_PER_PAGE = 50


class Mode(Enum):
    default = "all"
    all = "all"
    scrape_only = "scrape only"
    score_only = "score only"


def xpath_soup(element):
    # type: (typing.Union[bs4.element.Tag, bs4.element.NavigableString]) -> str
    """
    https://gist.github.com/ergoithz/6cf043e3fdedd1b94fcf
    Generate xpath from BeautifulSoup4 element.
    :param element: BeautifulSoup4 element.
    :type element: bs4.element.Tag or bs4.element.NavigableString
    :return: xpath as string
    :rtype: str
    """
    components = []
    child = element if element.name else element.parent
    for parent in child.parents:  # type: bs4.element.Tag
        siblings = parent.find_all(child.name, recursive=False)
        components.append(
            child.name if 1 == len(siblings) else "%s[%d]" % (
                child.name,
                next(i for i, s in enumerate(siblings, 1) if s is child)
            )
        )
        child = parent
    components.reverse()
    return "/%s" % "/".join(components)


def apply_filters(driver: webdriver, filters_dict: dict, input_soup_element: BeautifulSoup()):
    for key, val in filters_dict.items():
        р3: BeautifulSoup() = None
        legend: BeautifulSoup() = None
        span: BeautifulSoup() = None
        key_soup: BeautifulSoup() = None
        h3 = input_soup_element.find("h3", string=key)
        if h3:
            key_soup = h3.find_parent("div", class_="cBox cBox--content")
        else:
            legend = input_soup_element.find("legend", string=key)
            if legend:
                key_soup = legend.find_parent("div", class_="g-row u-margin-bottom-9")
            else:
                span = input_soup_element.find("span", string=key)
                if span:
                    key_soup = span.find_parent("div")
                else:
                    label = input_soup_element.find("label", string=key)
                    if label:
                        key_soup = label.find_parent("div")
        if isinstance(val, dict):
            apply_filters(driver, val, key_soup)
        # checkboxes
        elif isinstance(val, bool) and val:
            key_soup = input_soup_element.find(string=key)
            xpath = xpath_soup(key_soup)
            label_element = WebDriverWait(driver, DELAY).until(ec.presence_of_element_located((By.XPATH, xpath)))
            driver.execute_script("arguments[0].click();", label_element)
        # dropdowns
        elif isinstance(val, list) and val:
            variant = 0
            # multiselect
            if ["form-group", "multiselect-dropdown"] == key_soup["class"]:
                dropdown_element_soup = key_soup.find("span", class_="caret")
                xpath = xpath_soup(dropdown_element_soup)
                dropdown_element = WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.XPATH, xpath)))
                dropdown_element.click()
                for val_item in val:
                    dropdown_item_soup = key_soup.find("span", class_="text", string=val_item)
                    xpath = xpath_soup(dropdown_item_soup)
                    dropdown_item = WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.XPATH, xpath)))
                    dropdown_item.click()
                dropdown_element.click()
            # select and exclude car make and model
            else:
                for val_item in val:
                    for val_item_key, val_item_val in val_item.items():
                        val_item_key_span_soup = key_soup.find_all("span")
                        val_item_key_div_soup = val_item_key_span_soup[variant].find_parent("div")
                        # input text
                        if val_item_key_span_soup[variant].get("class") == ["dropdown-text"]:
                            if val_item_val:
                                input_soup = val_item_key_div_soup.find("input")
                                xpath = xpath_soup(input_soup)
                                input_element = WebDriverWait(driver, DELAY).until(
                                    ec.presence_of_element_located((By.XPATH, xpath)))
                                input_element.click()
                                input_element.send_keys(val_item_val)
                        # dropdowns
                        else:
                            if val_item_val:
                                select_soup = val_item_key_div_soup.find("select")
                                xpath = xpath_soup(select_soup)
                                select = Select(WebDriverWait(driver, DELAY).until(
                                    ec.presence_of_element_located((By.XPATH, xpath))))
                                select.select_by_visible_text(val_item_val)
                                driver.implicitly_wait(2)
                        variant += 1
        elif (isinstance(val, str) or isinstance(val, int)) and val:
            if key == "Мощность единицы измерения":
                pass
            # sliders
            elif str(key).endswith(" от") or str(key).endswith(" до"):
                main_key = key[:-3]
                side = "left"
                if str(key).endswith(" до"):
                    side = "right"
                span = input_soup_element.find("span", string=main_key)
                div_slider = span.find_parent("div").find("div", class_=f"slider-input u-pull-{side} default-value")
                input_soup = div_slider.find("input")
                xpath = xpath_soup(input_soup)
                input_element = WebDriverWait(driver, DELAY).until(ec.presence_of_element_located((By.XPATH, xpath)))
                input_element.click()
                input_element.send_keys(val)
            else:
                # single select dropdown
                select_soup = key_soup.find("select")
                if select_soup:
                    xpath = xpath_soup(select_soup)
                    select = Select(
                        WebDriverWait(driver, DELAY).until(ec.presence_of_element_located((By.XPATH, xpath))))
                    select.select_by_visible_text(val)
                # radiobutton
                else:
                    radiobutton_soup = key_soup.find("label", string=val)
                    xpath = xpath_soup(radiobutton_soup)
                    radiobutton_element = WebDriverWait(driver, DELAY).until(
                        ec.presence_of_element_located((By.XPATH, xpath)))
                    radiobutton_element.click()


def get_numeric_value(input_string):
    result = ""
    for num in re.findall("[0-9]+", input_string):
        result += num
    return int(result)


def get_date_value(input_string):
    matches = re.search(r"(?P<month>\d+) *\/ *(?P<year>\d+)", input_string)
    year = matches.group("year")
    month = matches.group("month")
    result = f"{year}-{month}"
    return result


def get_tech_data(soup, parameter, parameter_type="number", parameter_id=0):
    if soup.find_all("span", string=parameter):
        value = soup.find_all("span", string=parameter)[parameter_id].find_next("span").get_text()
    else:
        value = "0"
    if parameter_type == "number":
        return get_numeric_value(value)
    elif parameter_type == "date":
        return get_date_value(value)
    else:
        return value


def get_parking_data(parking: list):
    parking_front = False
    parking_rear = False
    parking_camera = False
    parking_auto_parking = False

    if "Спереди" in parking:
        parking_front = True
    if "Сзади" in parking:
        parking_rear = True
    if "Камера" in parking:
        parking_camera = True
    if "Системы автоматического рулевого управления" in parking:
        parking_auto_parking = True

    return parking_front, parking_rear, parking_camera, parking_auto_parking


def get_characteristics(driver: webdriver):
    t = Translator
    characteristics = {}

    soup = BeautifulSoup(driver.page_source, "lxml")

    characteristics_soup = soup.find("h3", string="Характеристики").find_next("div").find_all("p")
    for characteristic_soup in characteristics_soup:
        characteristics[t.translate_characteristic(characteristic_soup.get_text())] = True

    return characteristics


def get_car_info(driver: webdriver):
    url = driver.current_url
    soup = BeautifulSoup(driver.page_source, "lxml")

    ad_subject = soup.find("h1").get_text()

    matches = re.search(r"(?P<make>\w+) *(?P<model>\w+)", ad_subject.replace("<", "").replace(">", ""))
    make = matches.group("make").capitalize()
    model = matches.group("model").capitalize()

    is_rs = False
    if "RS" in ad_subject:
        is_rs = True

    colour = get_tech_data(soup, "Цвет", "string")
    car_type = get_tech_data(soup, "Категория", "string", 1).split(",")[0]
    fuel_type = get_tech_data(soup, "Топливо", "string").split(",")[0]
    kilometers = get_tech_data(soup, "Пробег")
    cubic_capacity = get_tech_data(soup, "Объем двигателя")
    registration_date = get_tech_data(soup, "Первая регистрация", "date")

    if soup.find("div", class_="price-box cBox-body").find(text="НДС не возмещается"):
        brutto_price = get_numeric_value(soup.find("span", class_="netto-price u-text-bold").get_text())
        netto_price = None
    else:
        brutto_price = get_numeric_value(soup.find("span", class_="brutto-price u-text-bold").get_text())
        netto_price = get_numeric_value(soup.find("p", class_="netto-price").get_text())

    parking = get_tech_data(soup, "Датчики парковки", "string").replace(", ", ",").split(",")
    parking_front, parking_rear, parking_camera, parking_auto_parking = get_parking_data(parking)

    characteristics = get_characteristics(driver)

    car_info = {
        "url": url,
        "Описаие": ad_subject,
        "Марка": make,
        "Модель": model,
        "RS": is_rs,
        "Цвет": colour,
        "Тип": car_type,
        "Топливо": fuel_type,
        "Пробег": kilometers,
        "Объем двигателя": cubic_capacity,
        "Первая регистрация": registration_date,
        "Цена брутто": brutto_price,
        "Цена нетто": netto_price,
        "Датчики парковки": parking,
        "Датчики парковки спереди": parking_front,
        "Датчики парковки сзади": parking_rear,
        "Датчики парковки камера": parking_camera,
        "Датчики парковки автопаркинг": parking_auto_parking
    }

    car_info.update(characteristics)
    car_info.update({"url": url})

    return car_info


def move_columns_to_position(df, columns, position):
    if isinstance(columns, list):
        columns_list = columns
    else:
        columns_list = [columns]

    columns_list.reverse()

    for column in columns_list:
        mid = df[column]
        df.drop(labels=[column], axis=1, inplace=True)
        df.insert(position, column, mid)

    return df


def scrape_data(filters_file, output_file):
    t = time.perf_counter()

    filters_url = "https://www.mobile.de/ru/расширенный-поиск/новое/vhc:car/pg:dspcar"

    options = webdriver.ChromeOptions()
    options.add_experimental_option("detach", True)
    driver = webdriver.Chrome("./scripts/chromedriver", chrome_options=options)

    driver.get(filters_url)
    filters_page_soup = BeautifulSoup(driver.page_source, "lxml")

    # accept cookies
    WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.ID, "gdpr-consent-accept-button"))).click()

    # collapse makeModelVariants
    collapse_button_soups = filters_page_soup.find_all("button",
                                                       class_="btn btn-collapse js-show-tooltip js-toggle-button js-toggle-makeModelVariants u-pull-right collapsed")
    for collapse_button_soup in collapse_button_soups:
        collapse_button_xpath = xpath_soup(collapse_button_soup)
        collapse_button = WebDriverWait(driver, DELAY).until(
            ec.element_to_be_clickable((By.XPATH, collapse_button_xpath)))
        driver.execute_script("arguments[0].click();", collapse_button)

    # apply filters
    with open(filters_file, encoding="utf-8") as f:
        filters = json.load(f)
    apply_filters(driver, filters, filters_page_soup)

    # click search button
    search_button_soup = filters_page_soup.find("input",
                                                class_="btn btn--orange btn--s u-pull-right js-show-results js-track-event")
    search_button_xpath = xpath_soup(search_button_soup)
    WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.XPATH, search_button_xpath))).click()

    # change currency to Euro
    time.sleep(TIME_SLEEP)
    currency_dropdown = Select(
        WebDriverWait(driver, DELAY).until(ec.presence_of_element_located((By.ID, "currencies"))))
    currency_dropdown.select_by_visible_text("Euro")

    time.sleep(TIME_SLEEP)
    search_page_soup = BeautifulSoup(driver.page_source, "lxml")

    # set number of results per page
    cars_per_page_soup = search_page_soup.find("a", class_="pagination-number btn btn--muted btn--s",
                                               string=CARS_PER_PAGE)
    cars_per_page_xpath = xpath_soup(cars_per_page_soup)
    WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.XPATH, cars_per_page_xpath))).click()

    # get total cars found
    search_result_header = search_page_soup.find("div",
                                                 "search-result-header g-col-12 js-search-result-header hidden-print")
    total_cars_found = get_numeric_value(search_result_header.get("data-result-count"))

    car_info_list = []
    page_number = 1
    total_cars = 0
    while True:
        try:
            WebDriverWait(driver, DELAY).until(ec.presence_of_element_located((By.CLASS_NAME, "result-list-section")))
        except TimeoutException:
            time.sleep(TIME_SLEEP)
            driver.refresh()
            try:
                WebDriverWait(driver, DELAY).until(
                    ec.presence_of_element_located((By.CLASS_NAME, "result-list-section")))
            except TimeoutException:
                limit_soup = BeautifulSoup(driver.page_source, "lxml")
                limit = limit_soup.find(string="Измените критерии поиска или начните новый.")
                if limit:
                    print("Looks like you're reached the limit")
                    break
                else:
                    print("Issue with serch page")
                    break

        search_page_soup = BeautifulSoup(driver.page_source, "lxml")
        search_result_soup = search_page_soup.find("div",
                                                   class_="result-list-section js-result-list-section u-clearfix")

        # get actual page number
        try:
            WebDriverWait(driver, DELAY).until(
                ec.presence_of_element_located((By.CLASS_NAME, "pagination-page-numbers")))
            page_numbers = search_page_soup.find("span", class_="pagination-page-numbers")
            page_number_actual = page_numbers.find("a",
                                                   class_="disabled pagination-number btn btn--muted btn--s").get_text()
        except TimeoutException:
            page_number_actual = 1

        # remove advertisement items
        if search_result_soup.find("section"):
            search_result_soup.section.decompose()

        # select first car
        first_car_soup = search_result_soup.find("a")
        first_car_xpath = xpath_soup(first_car_soup)
        first_car = WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.XPATH, first_car_xpath)))
        time.sleep(TIME_SLEEP)
        current_url = driver.current_url
        first_car.click()

        car_number_on_page = 1
        while True:
            total_cars += 1

            car_navigation_class = "back-forth-nav js-back-forth-nav u-margin-9 u-pull-right"
            try:
                WebDriverWait(driver, DELAY).until(ec.presence_of_element_located((By.CLASS_NAME, "u-inline")))
            except TimeoutException:
                pass

            try:
                WebDriverWait(driver, DELAY).until(ec.url_changes(current_url))
            except TimeoutException:
                pass

            car_page_soup = BeautifulSoup(driver.page_source, "lxml")
            car_navigation = car_page_soup.find("div", class_=car_navigation_class)
            car_navigation_info = car_navigation.find("div")
            car_navigation_item = None
            if car_navigation_info:
                car_navigation_item = car_navigation_info.get_text()

            print(
                f"Processing car {str(total_cars).rjust(4)} / {total_cars_found}: {str(car_number_on_page).rjust(2)} on page {str(page_number).rjust(3)} || item: {str(car_navigation_item).rjust(12)} page {str(page_number_actual).rjust(3)}")

            car_info_list.append(get_car_info(driver))

            next_car_button_soup = car_page_soup.find("i",
                                                      class_="gicon-next-s icon--xs icon--grey-80 u-no-margin-right")
            # if car_number_on_page >= CARS_PER_PAGE or not next_car_button_soup:
            if not next_car_button_soup:
                print(f"Cars processed on page {page_number}: {car_number_on_page}")
                elapsed_time_seconds = time.perf_counter() - t
                elapsed_time_formatted = str(timedelta(seconds=elapsed_time_seconds))
                print(f"Elapsed time: {elapsed_time_formatted}")

                time.sleep(TIME_SLEEP)

                back_to_search_result_button_soup = car_page_soup.find("div", class_="back-to-srp u-pull-left").find(
                    "a")
                back_to_search_result_button_xpath = xpath_soup(back_to_search_result_button_soup)
                back_to_search_result_button = WebDriverWait(driver, DELAY).until(
                    ec.element_to_be_clickable((By.XPATH, back_to_search_result_button_xpath)))
                driver.execute_script("arguments[0].click();", back_to_search_result_button)
                break

            current_url = driver.current_url

            next_car_button_xpath = xpath_soup(next_car_button_soup)
            next_car_button = WebDriverWait(driver, DELAY).until(
                ec.element_to_be_clickable((By.XPATH, next_car_button_xpath)))
            driver.execute_script("arguments[0].click();", next_car_button)

            car_number_on_page += 1

        # read same page if no navigation info
        if car_navigation_info:
            print("Going to next page")
            try:
                WebDriverWait(driver, DELAY).until(ec.url_changes(current_url))
            except TimeoutException:
                pass
            try:
                WebDriverWait(driver, DELAY).until(
                    ec.presence_of_element_located((By.CLASS_NAME, "result-list-section")))
            except TimeoutException:
                pass
            try:
                WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.CLASS_NAME, "gicon-next-s")))
            except TimeoutException:
                pass

            search_page_soup = BeautifulSoup(driver.page_source, "lxml")
            next_page_button_soup = search_page_soup.find("i", class_="gicon-next-s icon--xs icon--right u-no-margin")
            if not next_page_button_soup:
                break

            next_page_button_xpath = xpath_soup(next_page_button_soup)
            next_page_button = WebDriverWait(driver, DELAY).until(
                ec.element_to_be_clickable((By.XPATH, next_page_button_xpath)))
            driver.execute_script("arguments[0].click();", next_page_button)

        page_number += 1

    driver.close()
    print(f"Total pages processed: {page_number}")
    print(f"Total cars processed: {total_cars}")

    car_info_list_unique = list({v["url"]: v for v in car_info_list}.values())

    print(f"Total unique cars processed: {len(car_info_list_unique)}")
    df = pd.DataFrame(car_info_list_unique)
    df = df.fillna(False)
    df.loc[df["Цена нетто"] == False, ["Цена нетто"]] = np.nan

    if output_file:
        df.to_csv(output_file, index=False, encoding="utf-8")

    total_elapsed_time_seconds = time.perf_counter() - t
    total_elapsed_time_formatted = str(timedelta(seconds=total_elapsed_time_seconds))

    print(f"Total elapsed time: {total_elapsed_time_formatted}")

    return df


def set_expenses(input_file, output_file):
    df = pd.read_csv(input_file, encoding="utf-8")

    expenses = ["Налог", "Цена с налогом"]
    df = df.drop(expenses, axis=1, errors="ignore")

    for i, row in df.iterrows():
        brutto_price = df.loc[i, "Цена брутто"]
        netto_price = df.loc[i, "Цена нетто"]
        sell_price = brutto_price
        if not np.isnan(netto_price):
            sell_price = netto_price

        t = Tax(
            sell_price,
            df.loc[i, "Топливо"],
            df.loc[i, "Первая регистрация"],
            df.loc[i, "Объем двигателя"]
        )
        df.loc[i, "Налог"] = round(t.get_tax(), 2)

    df["Цена с налогом"] = round(df["Цена нетто"].combine_first(df["Цена брутто"]) + df["Налог"], 2)

    expenses_fields_position = df.columns.get_loc("Цена нетто") + 1
    df = move_columns_to_position(df, expenses, expenses_fields_position)

    df.to_csv(output_file, index=False, encoding="utf-8")


def set_scores(input_file, scores_file, output_file):
    df = pd.read_csv(input_file, encoding="utf-8")
    with open(scores_file, encoding="utf-8") as f:
        score_config_full = json.load(f)

    scores = ["Оценка характеристик", "Рейтинг характеристик", "Рейтинг цена пробег", "Рейтинг цена бюджет", "Рейтинг"]
    df = df.drop(scores, axis=1, errors="ignore")

    budget = score_config_full.get("Бюджет")
    score_config = {int(k): v for k, v in score_config_full.get("Оценки").items()}
    score_config = collections.OrderedDict(sorted(score_config.items()))
    df["Оценка характеристик"] = 0
    for i, row in df.iterrows():
        score = 0
        for multiplier, characteristics in score_config.items():
            if characteristics:
                for characteristic in characteristics:
                    if characteristic in df.columns:
                        if df.loc[i, characteristic]:
                            score += multiplier
        df.loc[i, "Оценка характеристик"] = score

    df["Рейтинг характеристик"] = (df["Оценка характеристик"] * 1000000) / df["Цена с налогом"]
    df["Рейтинг цена пробег"] = 1000 - ((df["Цена с налогом"] / 10000) * (df["Пробег"] / 10000))
    df["Рейтинг цена бюджет"] = ((budget - df["Цена с налогом"]) / df["Цена с налогом"]) * 10000
    df["Рейтинг"] = df["Рейтинг характеристик"] + df["Рейтинг цена пробег"] + df["Рейтинг цена бюджет"]

    score_fields_position = df.columns.get_loc("Датчики парковки") - 1
    df = move_columns_to_position(df, scores, score_fields_position)

    favourite_characteristics_deque = deque([])
    for multiplier, characteristics in score_config.items():
        if characteristics:
            favourite_characteristics_deque.extendleft(characteristics)

    favourite_characteristics = list(favourite_characteristics_deque)

    favourite_characteristics_fields_position = df.columns.get_loc("Датчики парковки") + 1
    df = move_columns_to_position(df, favourite_characteristics, favourite_characteristics_fields_position)

    df = df.drop(["Цена с налогом средняя для характеристик"], axis=1, errors="ignore")
    df_1 = df.groupby(favourite_characteristics).agg({"Цена с налогом": "mean"}).rename(columns={
        "Цена с налогом": "Цена с налогом средняя для характеристик"}
    )
    df_1.reset_index(level=favourite_characteristics, inplace=True)
    df = pd.merge(df, df_1, how="inner", on=favourite_characteristics)
    df = move_columns_to_position(df, "Цена с налогом средняя для характеристик", df.columns.get_loc("Цена с налогом") + 1)

    df.to_csv(output_file, index=False, encoding="utf-8")


def main(filters_files: list, output_file: str, scores_file: str, mode):

    df = pd.DataFrame()
    pool = multiprocessing.Pool(4)
    func = partial(scrape_data, output_file=None)
    df = pd.concat(pool.map(func, filters_files))
    pool.close()
    pool.join()

    df = df.fillna(False)
    df.loc[df["Цена нетто"] == False, ["Цена нетто"]] = np.nan
    df.to_csv(output_file, index=False, encoding="utf-8")

    set_expenses(output_file, output_file)
    set_scores(output_file, scores_file, output_file)


if __name__ == "__main__":
    parser = ArgumentParser()
    parser.add_argument("-f", "--filters", dest="filters_files_string")
    parser.add_argument("-s", "--scores", dest="scores_file")
    parser.add_argument("-o", "--output", dest="output_file")
    parser.add_argument("-m", "--mode", dest="mode")
    args = parser.parse_args()

    filters_files_list = args.filters_files_string.split("*")

    main(filters_files_list, args.output_file, args.scores_file, args.mode)


    # scrape_data("test_filters.json", "test_output.csv")
    # set_expenses("test_output.csv", "test_output.csv")
    # set_scores("test_output.csv", "score.json", "test_output.csv")

    # scrape_data("filters_no_seat_skoda.json", "output_no_seat_skoda.csv")
    # scrape_data("filters_no_seat_vw.json",    "output_no_seat_vw.csv")
    #
    # df1 = pd.read_csv("output_no_seat_skoda.csv", encoding="utf-8")
    # df2 = pd.read_csv("output_no_seat_vw.csv", encoding="utf-8")
    # union = pd.concat([df1, df2], ignore_index=True)
    # union = union.fillna(False)
    # union.loc[union["Цена нетто"] == False, ["Цена нетто"]] = np.nan
    # union.to_csv("output_no_seat.csv", index=False, encoding="utf-8")
    #
    # set_expenses("output_no_seat.csv", "output_no_seat.csv")
    # set_scores("output_no_seat.csv", "score.json", "output_no_seat.csv")
    #
