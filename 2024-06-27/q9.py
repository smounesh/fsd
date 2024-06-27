# Task 9: Find All Permutations of a given string

from itertools import permutations
s = input("Enter a string: ")
perms = ["".join(p) for p in permutations(s)]
for perm in perms:
    print(perm)
