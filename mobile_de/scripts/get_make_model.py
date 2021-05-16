import json

from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.common.exceptions import TimeoutException
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as ec
from selenium.webdriver.support.select import Select
from selenium.webdriver.support.ui import WebDriverWait


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


DELAY = 10

filters_url = "https://www.mobile.de/ru/расширенный-поиск/новое/vhc:car/pg:dspcar"

options = webdriver.ChromeOptions()
options.add_experimental_option("detach", True)
driver = webdriver.Chrome("./chromedriver", chrome_options=options)

driver.get(filters_url)
filters_page_soup = BeautifulSoup(driver.page_source, "lxml")

# accept cookies
WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.ID, "gdpr-consent-accept-button"))).click()

select_make_soup = filters_page_soup.find(id="makeModelVariant1Make")
select_make_xpath = xpath_soup(select_make_soup)
make_options = select_make_soup.find_all("option")

cars_dict = {}
make = ""
models_list = []
for make_option in make_options:
    if not make_option.get("disabled"):
        models_list = []
        make = make_option.get_text()

        print(make)

        select = Select(WebDriverWait(driver, DELAY).until(ec.presence_of_element_located((By.XPATH, select_make_xpath))))
        select.select_by_visible_text(make)

        try:
            WebDriverWait(driver, DELAY).until(ec.element_to_be_clickable((By.ID, "makeModelVariant1Model")))
            filters_page_soup = BeautifulSoup(driver.page_source, "lxml")
            select_model_soup = filters_page_soup.find(id="makeModelVariant1Model")
            select_model_xpath = xpath_soup(select_model_soup)
            model_options = select_model_soup.find_all("option")

            for model_option in model_options:
                if not model_option.get("disabled"):
                    model = model_option.get_text()
                    print("   ", model)
                    models_list.append(model)
        except TimeoutException:
            print("")
            models_list.append("")
    cars_dict[make] = models_list

driver.close()

with open(r"..\data\cars.json", 'w', encoding="utf-8") as fp:
    json.dump(cars_dict, fp, ensure_ascii=False, indent=4)
