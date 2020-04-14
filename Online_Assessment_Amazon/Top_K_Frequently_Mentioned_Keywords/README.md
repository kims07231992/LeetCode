## Top K Frequently Mentioned Keywords

**Link:** https://leetcode.com/discuss/interview-question/542597/

Given a list of `reviews`, a list of `keywords` and an integer `k`. Find the most popular `k` keywords in order of most to least frequently mentioned.

The comparison of strings is case-insensitive. If keywords are mentioned an equal number of times in reviews, sort alphabetically.

**Example 1:**

    Input:
    k = 2
    keywords = ["anacell", "cetracular", "betacellular"]
    reviews = [
      "Anacell provides the best services in the city",
      "betacellular has awesome services",
      "Best services provided by anacell, everyone should use anacell",
    ]
    
    Output:
    ["anacell", "betacellular"]
    
    Explanation:
    "anacell" is occuring in 2 different reviews and "betacellular" is only occuring in 1 review.
    

* * *

Related problems:

*   [https://leetcode.com/problems/top-k-frequent-words/](https://leetcode.com/problems/top-k-frequent-words/)  
    [https://leetcode.com/problems/top-k-frequent-elements/](https://leetcode.com/problems/top-k-frequent-elements/)