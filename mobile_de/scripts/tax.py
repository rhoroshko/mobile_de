import datetime


class Tax:
    def __init__(self, price: int, fuel_type: str, first_registration: str, cubic_capacity: int):
        self.price = price
        self.fuel_type = fuel_type
        self.first_registration = first_registration
        self.cubic_capacity = cubic_capacity

    def get_base_rate(self):
        """
        :return: базова ставка
        """
        if self.fuel_type == "Бензиновый":
            if self.cubic_capacity <= 3000:
                return 50
            else:
                return 100
        elif self.fuel_type == "Дизельный":
            if self.cubic_capacity <= 3500:
                return 75
            else:
                return 150
        else:
            return 1

    def get_age_coefficient(self):
        """
        :return: коефіцієнт віку
        """
        registration_year = int(self.first_registration.split("-")[0])
        current_year = datetime.datetime.now().year

        age_coefficient = current_year - registration_year - 1
        if age_coefficient > 15:
            return 15
        elif age_coefficient <= 1:
            return 1
        else:
            return age_coefficient

    def get_excise(self):
        """
        :return: акциз
        """
        base_rate = self.get_base_rate()
        age_coefficient = self.get_age_coefficient()

        return base_rate * age_coefficient * self.cubic_capacity / 1000

    def get_toll(self):
        """
        :return: мито
        """
        return self.price * 0.1

    def get_vat(self):
        """
        :return: ПДВ
        """
        return 0.2 * (self.price + self.get_excise() + self.get_toll())

    def get_tax(self):
        """
        :return: вартість позмитнення
        """
        return self.get_excise() + self.get_toll() + self.get_vat()
