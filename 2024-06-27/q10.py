# Task 10: Print a pyramid of stars for the number of rows specified

rows = int(input("Enter number of rows: "))
for i in range(1, rows + 1):
    print(" " * (rows - i) + "*" * (2 * i - 1))
