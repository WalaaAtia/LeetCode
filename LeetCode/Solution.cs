using System;
using System.Collections.Generic;

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
