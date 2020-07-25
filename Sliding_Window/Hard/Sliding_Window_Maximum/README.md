﻿## Sliding Window Maximum

**Link:** https://leetcode.com/problems/sliding-window-maximum/

Given an array _nums_, there is a sliding window of size _k_ which is moving from the very left of the array to the very right. You can only see the _k_ numbers in the window. Each time the sliding window moves right by one position. Return the max sliding window.

**Follow up:**  
Could you solve it in linear time?

**Example:**

**Input:** _nums_ = `[1,3,-1,-3,5,3,6,7]`, and _k_ = 3
**Output:** `[3,3,5,5,6,7] 
**Explanation:**` 
Window position                Max
---------------               -----
\[1  3  -1\] -3  5  3  6  7       **3**
 1 \[3  -1  -3\] 5  3  6  7       **3**
 1  3 \[-1  -3  5\] 3  6  7      ** 5**
 1  3  -1 \[-3  5  3\] 6  7       **5**
 1  3  -1  -3 \[5  3  6\] 7       **6**
 1  3  -1  -3  5 \[3  6  7\]      **7**

**Constraints:**

*   `1 <= nums.length <= 10^5`
*   `-10^4 <= nums[i] <= 10^4`
*   `1 <= k <= nums.length`