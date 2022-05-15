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

            for (int i=0; i< nums.Length; i++)
            {
                var complimentaryNumber = target - nums[i];

                if (inputs.ContainsKey(complimentaryNumber))
                    return new int[] { inputs[complimentaryNumber], i };

                if(!inputs.ContainsKey(nums[i]))
                    inputs.Add(nums[i], i);
            }

            return new[] { -1, -1 };
        }

        /// <summary>
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
            var inputs = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var complimentaryNumber = target - numbers[i];

                if (inputs.ContainsKey(complimentaryNumber))
                    return new int[] { inputs[complimentaryNumber]+1, i+1 };

                if (!inputs.ContainsKey(numbers[i]))
                    inputs.Add(numbers[i], i);
            }

            return new[] { -1, -1 };
        }
    }
}
