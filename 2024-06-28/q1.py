# 1) Longest Substring Without Repeating Characters. That is in a given string find the longest substring that does not contain any character twice.
def length_of_longest_substring(s):
    char_map = {}
    left = 0
    max_length = 0
    for right in range(len(s)):
        if s[right] in char_map:
            left = max(left, char_map[s[right]] + 1)
        char_map[s[right]] = right
        max_length = max(max_length, right - left + 1)
    return max_length

