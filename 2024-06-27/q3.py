# Task 3: Take name and gender, print greeting with salutation

name = input("Enter your name: ")
gender = input("Enter your gender (M/F): ")
salutation = "Mr." if gender == "M" else "Ms."
print(f"Hello, {salutation} {name}!")
