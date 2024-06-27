# Task 7: Take 10 numbers and find the average of all the prime numbers in the collection

def is_prime(n):
    if n <= 1:
        return False
    for i in range(2, int(n**0.5) + 1):
        if n % i == 0:
            return False
    return True
numbers = [int(input(f"Enter number {i+1}: ")) for i in range(10)]
primes = [n for n in numbers if is_prime(n)]
print(f"Average of primes: {sum(primes) / len(primes) if primes else 0}")
