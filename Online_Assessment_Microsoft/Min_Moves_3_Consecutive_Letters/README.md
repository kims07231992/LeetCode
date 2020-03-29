## Min Moves to Obtain String Without 3 Identical Consecutive Letters

**Link:** https://leetcode.com/discuss/interview-question/398026/

You are given a string s consisting of N letters 'a' and/or 'b'.
In one move, you can swap one letter for the other ('a' for 'b' or 'b' for 'a')

Write a functon solution that, given such a string S, returns the minimum number of moves required 
to obtain a string containing no instances of three identical consecutive letters.

Conditions:

*   N is an integer within the range [0, ..., 200,000]
*   String s consists only of the characters 'a' and/or 'b'

**Example 1:**

    Input: S = "baaaaa"
    Output: 1
    Explanation:
    The string without three identical consecutive letters which can be obtained in one move is "baabaa".

**Example 2:**

    Input: S = "baaabbaabbba"
    Output: 2

**Example 3:**

    Input: S = "baabab"
    Output: 0