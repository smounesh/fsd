# Task 5: Add validation for the entered name, age, date of birth, and phone, print details in proper format

import re
def validate_phone(phone):
    return re.match(r"^\d{10}$", phone)
name = input("Enter your name: ")
age = input("Enter your age: ")
dob = input("Enter your date of birth: ")
phone = input("Enter your phone number: ")
if validate_phone(phone):
    print(f"Name: {name}\nAge: {age}\nDate of Birth: {dob}\nPhone: {phone}")
else:
    print("Invalid phone number")
