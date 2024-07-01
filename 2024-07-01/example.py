# 1) Python class
class MyClass:
    def __init__(self, name):
        self.name = name

    def greet(self):
        print(f"Hello, {self.name}!")



# 2) Inheritance in Python
class ParentClass:
    def __init__(self):
        self.value = "I am a parent class"

    def show(self):
        print(self.value)

class ChildClass(ParentClass):
    def __init__(self):
        super().__init__()
        self.value = "I am a child class"



# 3) Polymorphism in Python
class Dog:
    def speak(self):
        return "Woof!"

class Cat:
    def speak(self):
        return "Meow!"

def animal_sound(animal):
    print(animal.speak())



# 4) Modules in Python - Using the math module
import math
number = 16
sqrt_number = math.sqrt(number)
print(f"The square root of {number} is {sqrt_number}.")



# 5) Exception Handling (Try Except)
try:
    x = 10 / 0
except ZeroDivisionError:
    print("Cannot divide by zero.")
finally:
    print("This block is always executed.")




# 6) File handling - Read and Write
# Writing to a file
with open("example.txt", "w") as file:
    file.write("Hello, World!")

# Reading from a file
with open("example.txt", "r") as file:
    content = file.read()
    print(content)