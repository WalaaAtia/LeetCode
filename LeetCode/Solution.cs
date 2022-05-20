using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LeetCode
{
    public class Solution
    {
        /// <summary>
        /// #0001 - TWOSUM 
        ///Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        ///You can return the answer in any order.
        ///
        ///Example 1:
        ///
        ///Input: nums = [2, 7, 11, 15], target = 9
        ///Output:[0,1]
        ///Explanation: Because nums[0] +nums[1] == 9, we return [0, 1].
        ///Example 2:
        ///
        ///Input: nums = [3, 2, 4], target = 6
        ///Output:[1,2]
        ///Example 3:
        ///
        ///Input: nums = [3, 3], target = 6
        ///Output:[0,1]
        ///
        ///Constraints:
        ///
        /// 2 <= nums.length <= 10^4
        /// 10^9 <= nums[i] <= 10^9
        /// 10^9 <= target <= 10^9
        ///Only one valid answer exists.
        ///
        ///Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
        ///
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            var inputs = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complimentaryNumber = target - nums[i];

                if (inputs.ContainsKey(complimentaryNumber))
                    return new int[] { inputs[complimentaryNumber], i };

                if (!inputs.ContainsKey(nums[i]))
                    inputs.Add(nums[i], i);
            }

            return new[] { -1, -1 };
        }

        /// <summary>
        /// #0167 TWOSUMII
        /// Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. 
        /// Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.        
        /// Return the indices of the two numbers, index1 and index2, added by one as an integer array[index1, index2] of length 2.
        ///
        /// The tests are generated such that there is exactly one solution.You may not use the same element twice.
        ///
        /// Your solution must use only constant extra space.
        ///
        /// Example 1:
        ///
        /// Input: numbers = [2, 7, 11, 15], target = 9
        /// Output: [1,2]
        /// Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2.We return [1, 2].
        /// Example 2:
        ///
        /// Input: numbers = [2, 3, 4], target = 6
        /// Output: [1,3]
        /// Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3.We return [1, 3].
        /// Example 3:
        ///
        /// Input: numbers = [-1, 0], target = -1
        /// Output: [1,2]
        /// Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2.We return [1, 2].
        ///
        /// Constraints:
        ///
        /// 2 <= numbers.length <= 3 * 104
        /// -1000 <= numbers[i] <= 1000
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSumII(int[] numbers, int target)
        {
            var startIndex = 0;
            var endIndex = numbers.Length - 1;

            while (numbers[startIndex] + numbers[endIndex] != target)
            {
                if (startIndex == endIndex)
                    return new[] { -1, -1 };

                if (numbers[startIndex] + numbers[endIndex] > target)
                    endIndex--;
                else
                    startIndex++;
            }

            return new[] { startIndex + 1, endIndex + 1 };
        }

        /// <summary>
        /// #0002 ADD TWO NUMBERS
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// 
        /// Example 1
        /// Input: l1 = [2,4,3], l2 = [5,6,4]
        /// Output: [7,0,8]
        /// Explanation: 342 + 465 = 807.
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;

            var result = new ListNode();

            var rightOperand = (l1 != null) ? l1.val : 0;
            var leftOperand = (l2 != null) ? l2.val : 0;
            var nextRightNode = (l1 != null) ? l1.next : null;
            var nextLefttNode = (l2 != null) ? l2.next : null;

            result.val = rightOperand + leftOperand;

            if (result.val > 9)
            {
                result.val = result.val - 10;
                nextRightNode = AddTwoNumbers(nextRightNode, new ListNode(1, null));
            }

            result.next = AddTwoNumbers(nextRightNode, nextLefttNode);

            return result;
        }

        /// <summary>
        /// #1302 Deepest Leaves Sum
        /// Given the root of a binary tree, return the sum of values of its deepest leaves
        /// 
        /// Example:
        /// Input: root = [1,2,3,4,5,null,6,7,null,null,null,null,8]
        /// Output: 15
        /// 
        /// Constraints:
        /// The number of nodes in the tree is in the range[1, 104].
        /// 1 <= Node.val <= 100
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int DeepestLeavesSum(TreeNode root)
        {
            if (root.left == null && root.right == null)
                return root.val;

            var maxLevelSumPair = new ValueTuple<short, int>(0, 0);
            DeepestLeavesSum(root, 0, ref maxLevelSumPair);

            return maxLevelSumPair.Item2;
        }

        public void DeepestLeavesSum(TreeNode root, short level, ref ValueTuple<short, int> maxLevelSumPair)
        {
            if (level == maxLevelSumPair.Item1)
            {
                maxLevelSumPair.Item2 += root.val;
            }
            else if(level > maxLevelSumPair.Item1)
            {
                maxLevelSumPair.Item1 = level;
                maxLevelSumPair.Item2 = root.val;
            }
            
            level++;
            if (root.left != null)
            {
                DeepestLeavesSum(root.left, level, ref maxLevelSumPair);
            }
            if (root.right != null)
            {
                DeepestLeavesSum(root.right, level, ref maxLevelSumPair);
            }
        }

        /// <summary>
        /// #0030 FIND SUBSTRING
        /// You are given a string s and an array of strings words of the same length. 
        /// Return all starting indices of substring(s) in s that is a concatenation of each word in words exactly once, in any order, and without any intervening characters.
        /// You can return the answer in any order.
        /// Example 1:
        /// Input: s = "barfoothefoobarman", words = ["foo","bar"]
        /// Output: [0,9]
        /// Explanation: Substrings starting at index 0 and 9 are "barfoo" and "foobar" respectively.
        /// The output order does not matter, returning[9, 0] is fine too.
        /// Example 2:
        /// Input: s = "wordgoodgoodgoodbestword", words = ["word", "good", "best", "word"]
        ///        Output: []
        /// Example 3:
        /// Input: s = "barfoofoobarthefoobarman", words = ["bar", "foo", "the"]
        /// Output: [6,9,12]
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();            

            if (string.IsNullOrEmpty(s) || words.Length == 0)
                return result;

            var segmentLength = words[0].Length;
            var concatenatedLength = words.Length * segmentLength;

            if (concatenatedLength > s.Length)
                return result;

            for (int i = 0; i <= s.Length - concatenatedLength; i++)
            {
                var wordList = new List<string>(words);
                var foundSegmentsIndexes = new HashSet<int>();

                var segmentIndex = FindStringSegmentInWorldList(s, wordList, i, segmentLength);
                if (segmentIndex < 0)
                    continue;

                foundSegmentsIndexes.Add(segmentIndex);
                wordList[segmentIndex] = string.Empty;


                for (int nextSegmentIndex = i + segmentLength; nextSegmentIndex <= s.Length - segmentLength; nextSegmentIndex+= segmentLength)
                {
                    segmentIndex = FindStringSegmentInWorldList(s, wordList, nextSegmentIndex, segmentLength);
                    if (segmentIndex < 0)
                        break;

                    if (!foundSegmentsIndexes.Add(segmentIndex))
                        break;                                       

                    if (foundSegmentsIndexes.Count == words.Length)
                        break;

                    wordList[segmentIndex] = string.Empty;
                }

                if (foundSegmentsIndexes.Count == words.Length)
                    result.Add(i);
            }

            return result;
        }
        internal int FindStringSegmentInWorldList(string s, List<string> wordList, int startIndex, int segmentLength)
        {
            var segmentToExamine = s.Substring(startIndex, segmentLength);
            return wordList.FindIndex(x => x == segmentToExamine);
        }

        /// <summary>
        /// #0125 Valid Palindrome
        /// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. 
        /// Alphanumeric characters include letters and numbers.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            var processedString = new string(s.Where(ch => Char.IsLetterOrDigit(ch)).ToArray()).ToLower();

            if (processedString.Equals(ReverseString(processedString)))
                return true;

            return false;
        }

        internal string ReverseString(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            if (x < 10)
                return true;

            return (x == ReverseNumber(x));
        }

        internal int ReverseNumber(int x)
        {
            int y = 0;

            while (x != 0)
            {
                y = y*10 + (x % 10);

                x = x / 10;
            }

            return y;
        }

        /// <summary>
        /// #0044 Wildcard Matching
        /// Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:
        /// '?' Matches any single character.
        /// '*' Matches any sequence of characters (including the empty sequence).
        /// The matching should cover the entire input string (not partial).
        /// </summary>
        /// <param name="s">input string</param>
        /// <param name="p">matching pattern</param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            // If the pattern is exactly similar to the string, then it's a match
            if (p == s)
                return true;

            // if the pattern doesn't have any wild card, and it's not similar to the string, then it's not a match.
            if (p.IndexOf('*') == -1 && p.IndexOf('?') == -1)
            {
                if (s != p)
                    return false;
            }
           
            // if the pattern striped of any '*' has more characters than the string, then it's not a match.
            if (s.Length < p.Replace("*", string.Empty).Length)
                return false;


            if (!p.Contains('*'))
            {
                if (s.Length != p.Length)
                    return false;

                return IsPatternWithoutAsterixExists(s, p);
            }
            else
            {
                p = RemoveDuplicateConsecutiveWildCard(p);

                if (p == "*")
                    return true;

                if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(p.Replace("*", string.Empty)))
                    return true;

                if (IsMatch(s, p.Replace("*", string.Empty)))
                    return true;

                // if the pattern has only wild cards.
                if (string.IsNullOrEmpty(p.Replace("*", string.Empty).Replace("?", string.Empty)))
                {
                    if (s.Length >= p.Replace("*", string.Empty).Length)
                        return true;
                }

                // first character check
                if (p[0] != '*' && p[0] != '?' && p[0] != s[0])
                    return false;
                // last character check
                if (p[p.Length-1] != '*' && p[p.Length - 1] != '?' && p[p.Length - 1] != s[s.Length-1])
                    return false;

                if (p.StartsWith("*") && p.EndsWith("*") && !p.Substring(1, p.Length - 2).Contains('*'))
                    return IsPatternWithoutAsterixExists(s, p.Substring(1, p.Length - 2));

                if (p.StartsWith("*") && !p.EndsWith("*") && !p.Substring(1, p.Length - 2).Contains('*'))
                    return IsPatternWithoutAsterixExists(s.Substring(s.Length-p.Length+1), p.Substring(1, p.Length - 1));

                if (!p.StartsWith("*") && p.EndsWith("*") && !p.Substring(1, p.Length - 2).Contains('*'))
                    return IsPatternWithoutAsterixExists(s.Substring(0, p.Length-1), p.Substring(0, p.Length - 1));
                if (p.StartsWith('*'))
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (IsMatch(s.Substring(i), p.Substring(1)))
                            return true;
                    }
                    return false;
                }
                
            }

            int stringIndex = 0, patternIndex = 0;

            bool match = false;

            while (stringIndex < s.Length && patternIndex < p.Length)
            {
                match = false;

                if (p[patternIndex] != '?' && p[patternIndex] != '*' && p[patternIndex] != s[stringIndex])
                    return false;

                if (p[patternIndex] == s[stringIndex] || p[patternIndex] == '?')
                {
                    match = true;
                    patternIndex++;
                    stringIndex++;
                }

                else if (p[patternIndex] == '*')
                {
                    match = true;
                    patternIndex++;

                    // If '*' is the last character in the pattern, then it's a match.
                    if (patternIndex >= p.Length)
                        return true;

                    // if the next character in the pattern is not a '?' and it's not to be found in the remaining part of the provided string, then it's not a match.
                    var nextStringIndex = s.IndexOf(p[patternIndex], stringIndex);
                    if (nextStringIndex < 0 && p[patternIndex] != '?')
                        return false;

                    // move the string index to the next character to examine.
                    stringIndex = (nextStringIndex < 0)? stringIndex+=2 : nextStringIndex + 1;

                    // look for other options for the next charachter match
                    var nextSegmentStartIndex = stringIndex;
                    while (nextSegmentStartIndex < s.Length)
                    {
                        nextStringIndex = s.IndexOf(p[patternIndex], nextSegmentStartIndex);
                        if (nextStringIndex < 0 && p[patternIndex] != '?')
                            break;

                        if (nextStringIndex < 0)
                            nextStringIndex = nextSegmentStartIndex;

                        if (IsMatch(s.Substring(nextStringIndex), p.Substring(patternIndex)))
                            return true;

                        nextSegmentStartIndex++;
                    }
                    patternIndex++;                    
                }

                if (stringIndex < s.Length && patternIndex >= p.Length)
                    return false;
                if (stringIndex >= s.Length && patternIndex < p.Length && p.Substring(patternIndex).Replace("*", string.Empty).Length > 0)
                    return false;
            }

            return match;
        }

        private string RemoveDuplicateConsecutiveWildCard(string s)
        {
            if (s.Length <= 1)
                return s;

            else if (s[0] == '*' && s[0] == s[1])
                return RemoveDuplicateConsecutiveWildCard(s.Substring(1));
            else
                return s[0] + RemoveDuplicateConsecutiveWildCard(s.Substring(1));
        }

        private bool IsPatternWithoutAsterixExists(string s, string p)
        {
            if (s.Contains(p))
                return true;

            // If pattern has no single wildcards, then there is no match, otherwise the first check would have returned true.
            else if (!p.Contains('?'))
                return false;

            // if the pattern has no other characters but '?' and the length of the pattern is less or equal to the string, then it's a match.
            if (string.IsNullOrEmpty(p.Replace("?", string.Empty)) && (p.Length <= s.Length))
                return true;

            // in case the pattern has a mix of alphanumeric characters and '?' charcters.
            var patternIndex = 0;
            var stringIndex = 0;

            while (stringIndex <= s.Length - p.Length)
            {
                // looking for a match to the first character in the pattern
                // if the current string character doesn't match, move to the next string character
                if (s[stringIndex] != p[patternIndex] && p[patternIndex] != '?')
                {
                    stringIndex++;
                        continue;
                }

                // otherwise if the current string character matches the first character in the patters,
                // then recursively examine the next string characters for matching with the rest of the pattern.
                if (IsPatternWithoutAsterixExists(s.Substring(stringIndex + 1, p.Length - 1), p.Substring(patternIndex + 1)))
                    return true;
                else
                    stringIndex++;
            }

            // If the call reaches here, then there was no match found.
            return false;
        }

        /// <summary>
        /// ou are given an m x n integer array grid. There is a robot initially located at the top-left corner (i.e., grid[0][0]). 
        /// The robot tries to move to the bottom-right corner (i.e., grid[m-1][n-1]). The robot can only move either down or right at any point in time.
        /// An obstacle and space are marked as 1 or 0 respectively in grid.A path that the robot takes cannot include any square that is an obstacle.
        /// Return the number of possible unique paths that the robot can take to reach the bottom-right corner.
        /// The testcases are generated so that the answer will be less than or equal to 2 * 109.
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var gridLength = obstacleGrid.Length;
            var gridWidth = obstacleGrid[0].Length;

            if (obstacleGrid[0][0] == 1)
                return 0;

            if (gridWidth == 1 && gridLength == 1)
                return 1;

            var rightObstacleGrid = new int[gridLength][]; // width--
            var downObstacleGrid = new int[gridLength-1][]; // full width

            for (int i = 0; i < gridLength; i++)
            {
                rightObstacleGrid[i] = new int[gridWidth -1];
                
                if(i != 0)
                    downObstacleGrid[i-1] = new int[gridWidth];

                for (int j = 0; j < gridWidth; j++)
                {
                    if (j != 0)
                        rightObstacleGrid[i][j-1] = obstacleGrid[i][j];
                    if(i !=0)
                        downObstacleGrid[i-1][j] = obstacleGrid[i][j];
                }
            }
            
            var paths = 0;

            // moving right.
            if(gridWidth > 1)
                paths += UniquePathsWithObstacles(rightObstacleGrid);

            // moving down.
            if(gridLength > 1)
                paths += UniquePathsWithObstacles(downObstacleGrid);

            return paths;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
