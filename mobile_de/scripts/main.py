from collections import deque
import collections
import json
import re
import time
import typing
from datetime import timedelta
from enum import Enum
import os

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
        ??3: BeautifulSoup() = None
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
            if key == "???????????????? ?????????????? ??????????????????":
                pass
            # sliders
            elif str(key).endswith(" ????") or str(key).endswith(" ????"):
                main_key = key[:-3]
                side = "left"
                if str(key).endswith(" ????"):
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

    if "??????????????" in parking:
        parking_front = True
    if "??????????" in parking:
        parking_rear = True
    if "????????????" in parking:
        parking_camera = True
    if "?????????????? ?????????????????????????????? ???????????????? ????????????????????" in parking:
        parking_auto_parking = True

    return parking_front, parking_rear, parking_camera, parking_auto_parking


def get_characteristics(driver: webdriver):
    t = Translator
    characteristics = {}

    soup = BeautifulSoup(driver.page_source, "lxml")

    characteristics_soup = soup.find("h3", string="????????????????????????????").find_next("div").find_all("p")
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

    colour = get_tech_data(soup, "????????", "string")
    car_type = get_tech_data(soup, "??????????????????", "string", 1).split(",")[0]
    fuel_type = get_tech_data(soup, "??????????????", "string").split(",")[0]
    kilometers = get_tech_data(soup, "????????????")
    cubic_capacity = get_tech_data(soup, "?????????? ??????????????????")
    registration_date = get_tech_data(soup, "???????????? ??????????????????????", "date")

    if soup.find("div", class_="price-box cBox-body").find(text="?????? ???? ??????????????????????"):
        brutto_price = get_numeric_value(soup.find("span", class_="netto-price u-text-bold").get_text())
        netto_price = None
    else:
        brutto_price = get_numeric_value(soup.find("span", class_="brutto-price u-text-bold").get_text())
        netto_price = get_numeric_value(soup.find("p", class_="netto-price").get_text())

    parking = get_tech_data(soup, "?????????????? ????????????????", "string").replace(", ", ",").split(",")
    parking_front, parking_rear, parking_camera, parking_auto_parking = get_parking_data(parking)

    characteristics = get_characteristics(driver)

    car_info = {
        "url": url,
        "??????????????": ad_subject,
        "??????????": make,
        "????????????": model,
        "RS": is_rs,
        "????????": colour,
        "??????": car_type,
        "??????????????": fuel_type,
        "????????????": kilometers,
        "?????????? ??????????????????": cubic_capacity,
        "???????????? ??????????????????????": registration_date,
        "???????? ????????????": brutto_price,
        "???????? ??????????": netto_price,
        "?????????????? ????????????????": parking,
        "?????????????? ???????????????? ??????????????": parking_front,
        "?????????????? ???????????????? ??????????": parking_rear,
        "?????????????? ???????????????? ????????????": parking_camera,
        "?????????????? ???????????????? ??????????????????????": parking_auto_parking
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

    filters_file_name = os.path.basename(filters_file).ljust(50)

    t = time.perf_counter()

    filters_url = "https://www.mobile.de/ru/??????????????????????-??????????/??????????/vhc:car/pg:dspcar"

    print(f"{filters_file_name} Starting browser")

    options = webdriver.ChromeOptions()
    options.add_experimental_option("detach", True)
    options.add_argument("--disable-gpu")
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
    print(f"{filters_file_name} Applying filters")
    with open(filters_file, encoding="utf-8") as f:
        filters = json.load(f)
    apply_filters(driver, filters, filters_page_soup)

    # click search button
    print(f"{filters_file_name} Clicking search button")
    search_button_soup = filters_page_soup.find("input",
                                                class_="btn btn--orange btn--s u-pull-right js-show-results js-track-event")
    search_button_xpath = xpath_soup(search_button_soup)
    WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.XPATH, search_button_xpath))).click()

    # change currency to Euro
    print(f"{filters_file_name} Changing currency to Euro")
    time.sleep(TIME_SLEEP)
    currency_dropdown = Select(
        WebDriverWait(driver, DELAY).until(ec.presence_of_element_located((By.ID, "currencies"))))
    currency_dropdown.select_by_visible_text("Euro")

    time.sleep(TIME_SLEEP)
    search_page_soup = BeautifulSoup(driver.page_source, "lxml")

    # set number of results per page
    print(f"{filters_file_name} Set number of results per page: {CARS_PER_PAGE}")
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
                limit = limit_soup.find(string="???????????????? ???????????????? ???????????? ?????? ?????????????? ??????????.")
                if limit:
                    print(f"{filters_file_name} Looks like you're reached the limit")
                    break
                else:
                    print(f"{filters_file_name} Issue with search page")
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
            car_navigation_item_number = None
            car_navigation_item_number_from = None
            if car_navigation_info:
                car_navigation_item = car_navigation_info.get_text()
                car_navigation_item_number = str(car_navigation_item.split("/")[0]).strip().rjust(12)
                car_navigation_item_number_from = str(car_navigation_item.split("/")[1]).strip().rjust(6)

            print(f"{filters_file_name} Processing car: {car_navigation_item_number}/{car_navigation_item_number_from} page {str(page_number_actual).rjust(3)}")

            car_info_list.append(get_car_info(driver))

            next_car_button_soup = car_page_soup.find("i",
                                                      class_="gicon-next-s icon--xs icon--grey-80 u-no-margin-right")
            # if car_number_on_page >= CARS_PER_PAGE or not next_car_button_soup:
            if not next_car_button_soup:
                print(f"{filters_file_name} Cars processed on page {page_number}: {car_number_on_page}")
                elapsed_time_seconds = time.perf_counter() - t
                elapsed_time_formatted = str(timedelta(seconds=elapsed_time_seconds))
                print(f"{filters_file_name} Elapsed time: {elapsed_time_formatted}")

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
            print(f"{filters_file_name} Going to next page")
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
    print(f"{filters_file_name} Total pages processed: {page_number}")
    print(f"{filters_file_name} Total cars processed: {total_cars}")

    car_info_list_unique = list({v["url"]: v for v in car_info_list}.values())

    print(f"{filters_file_name} Total unique cars processed: {len(car_info_list_unique)}")
    df = pd.DataFrame(car_info_list_unique)
    df = df.fillna(False)
    df.loc[df["???????? ??????????"] == False, ["???????? ??????????"]] = np.nan

    if output_file:
        df.to_csv(output_file, index=False, encoding="utf-8")

    total_elapsed_time_seconds = time.perf_counter() - t
    total_elapsed_time_formatted = str(timedelta(seconds=total_elapsed_time_seconds))

    print(f"{filters_file_name} Total elapsed time: {total_elapsed_time_formatted}")

    return df


def set_expenses(input_file, output_file):
    df = pd.read_csv(input_file, encoding="utf-8")

    expenses = ["??????????", "???????? ?? ??????????????"]
    df = df.drop(expenses, axis=1, errors="ignore")

    for i, row in df.iterrows():
        brutto_price = df.loc[i, "???????? ????????????"]
        netto_price = df.loc[i, "???????? ??????????"]
        sell_price = brutto_price
        if not np.isnan(netto_price):
            sell_price = netto_price

        t = Tax(
            sell_price,
            df.loc[i, "??????????????"],
            df.loc[i, "???????????? ??????????????????????"],
            df.loc[i, "?????????? ??????????????????"]
        )
        df.loc[i, "??????????"] = round(t.get_tax(), 2)

    df["???????? ?? ??????????????"] = round(df["???????? ??????????"].combine_first(df["???????? ????????????"]) + df["??????????"], 2)

    expenses_fields_position = df.columns.get_loc("???????? ??????????") + 1
    df = move_columns_to_position(df, expenses, expenses_fields_position)

    df.to_csv(output_file, index=False, encoding="utf-8")


def set_scores(input_file, scores_file, output_file):
    df = pd.read_csv(input_file, encoding="utf-8")
    with open(scores_file, encoding="utf-8") as f:
        score_config_full = json.load(f)

    scores = ["???????????? ??????????????????????????", "?????????????? ??????????????????????????", "?????????????? ???????? ????????????", "?????????????? ???????? ????????????", "??????????????"]
    df = df.drop(scores, axis=1, errors="ignore")

    budget = score_config_full.get("????????????")
    score_config = {int(k): v for k, v in score_config_full.get("????????????").items()}
    score_config = collections.OrderedDict(sorted(score_config.items()))
    df["???????????? ??????????????????????????"] = 0
    for i, row in df.iterrows():
        score = 0
        for multiplier, characteristics in score_config.items():
            if characteristics:
                for characteristic in characteristics:
                    if characteristic in df.columns:
                        if df.loc[i, characteristic]:
                            score += multiplier
        df.loc[i, "???????????? ??????????????????????????"] = score

    df["?????????????? ??????????????????????????"] = (df["???????????? ??????????????????????????"] * 1000000) / df["???????? ?? ??????????????"]
    df["?????????????? ???????? ????????????"] = 1000 - ((df["???????? ?? ??????????????"] / 10000) * (df["????????????"] / 10000))
    df["?????????????? ???????? ????????????"] = ((budget - df["???????? ?? ??????????????"]) / df["???????? ?? ??????????????"]) * 10000
    df["??????????????"] = df["?????????????? ??????????????????????????"] + df["?????????????? ???????? ????????????"] + df["?????????????? ???????? ????????????"]

    score_fields_position = df.columns.get_loc("?????????????? ????????????????") - 1
    df = move_columns_to_position(df, scores, score_fields_position)

    favourite_characteristics_deque = deque([])
    for multiplier, characteristics in score_config.items():
        if characteristics:
            favourite_characteristics_deque.extendleft(characteristics)

    favourite_characteristics = list(favourite_characteristics_deque)

    favourite_characteristics_fields_position = df.columns.get_loc("?????????????? ????????????????") + 1
    df = move_columns_to_position(df, favourite_characteristics, favourite_characteristics_fields_position)

    df = df.drop(["???????? ?? ?????????????? ?????????????? ?????? ??????????????????????????"], axis=1, errors="ignore")
    df_1 = df.groupby(favourite_characteristics).agg({"???????? ?? ??????????????": "mean"}).rename(columns={
        "???????? ?? ??????????????": "???????? ?? ?????????????? ?????????????? ?????? ??????????????????????????"}
    )
    df_1.reset_index(level=favourite_characteristics, inplace=True)
    df = pd.merge(df, df_1, how="inner", on=favourite_characteristics)
    df = move_columns_to_position(df, "???????? ?? ?????????????? ?????????????? ?????? ??????????????????????????", df.columns.get_loc("???????? ?? ??????????????") + 1)

    df.to_csv(output_file, index=False, encoding="utf-8")


def main(filters_files: list, output_file: str, scores_file: str, mode):
    t = time.perf_counter()

    pool = multiprocessing.Pool(4)
    func = partial(scrape_data, output_file=None)
    df = pd.concat(pool.map(func, filters_files))
    pool.close()
    pool.join()

    total_elapsed_time_seconds = time.perf_counter() - t
    total_elapsed_time_formatted = str(timedelta(seconds=total_elapsed_time_seconds))

    print(f"All cars search took: {total_elapsed_time_formatted}")

    df = df.fillna(False)
    df.loc[df["???????? ??????????"] == False, ["???????? ??????????"]] = np.nan
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
