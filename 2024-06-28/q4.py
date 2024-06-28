# 4) Application to play the Cow and Bull game maintain score as well. - reff - Wordle of New York Times
def cow_and_bull(secret_word, guess):
    cows = 0  
    bulls = 0 
    for i in range(len(secret_word)):
        if guess[i] == secret_word[i]:
            cows += 1
        elif guess[i] in secret_word:
            bulls += 1
    return cows, bulls
