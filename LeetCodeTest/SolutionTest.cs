using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode;

namespace LeetCodeTest
{
    [TestClass]
    public class SolutionTest
    {
        [TestMethod]
        public void TwoSumTest()
        {
            var solution = new Solution();

            var result = (solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9));

            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 1);

            var result2 = (solution.TwoSum(new int[] { -6, 7, 11, 15 }, 9));

            Assert.AreEqual(result2[0], 0);
            Assert.AreEqual(result2[1], 3);

            var result3 = (solution.TwoSum(new int[] { -6, -6, 15, 15 }, 9));

            Assert.AreEqual(result3[0], 0);
            Assert.AreEqual(result3[1], 2);

        }

        [TestMethod]
        public void TwoSumIITest()
        {
            var solution = new Solution();

            var result = (solution.TwoSumII(new int[] { 2, 7, 11, 15 }, 9));

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);

            var result2 = (solution.TwoSumII(new int[] { 2,3,4 }, 6));

            Assert.AreEqual(result2[0], 1);
            Assert.AreEqual(result2[1], 3);

            var result3 = (solution.TwoSumII(new int[] { -1, 0 }, -1));

            Assert.AreEqual(result3[0], 1);
            Assert.AreEqual(result3[1], 2);

        }

        [TestMethod]
        public void AddTwoNumbersTest()
        {
            var solution = new Solution();

            var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            var result = solution.AddTwoNumbers(l1, l2);

            Assert.AreEqual(result.val, 7);
            Assert.AreEqual(result.next.val, 0);
            Assert.AreEqual(result.next.next.val, 8);
        }

        [TestMethod]
        public void AddTwoNumbersTest2()
        {
            var solution = new Solution();

            var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));

            var result = solution.AddTwoNumbers(l1, l2);

            Assert.AreEqual(result.val, 8);
            Assert.AreEqual(result.next.val, 9);
            Assert.AreEqual(result.next.next.val, 9);
            Assert.AreEqual(result.next.next.next.val, 9);
            Assert.AreEqual(result.next.next.next.next.val, 0);
            Assert.AreEqual(result.next.next.next.next.next.val, 0);
            Assert.AreEqual(result.next.next.next.next.next.next.val, 0);
            Assert.AreEqual(result.next.next.next.next.next.next.next.val, 1);
        }

        [TestMethod]
        public void DeepestLeavesSumTest()
        {
            // [38,43,70,16,null,78,91,null,71,27,null,71,null,null,null,71] Expected 71
            var solution = new Solution();

            var node = new TreeNode(38, new TreeNode(43, 
                new TreeNode(16, null, new TreeNode(71, null, null)), null), 
                new TreeNode(70, new TreeNode(78,new TreeNode(27, new TreeNode(71, null, null), null),null), new TreeNode(91,new TreeNode(71, null, null),null)));

            var result = solution.DeepestLeavesSum(node);

            Assert.AreEqual(result, 71);
        }

        [TestMethod]
        public void FindSubstringTest()
        {            
            var solution = new Solution();

            var result = solution.FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" });
            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 9);

            var result2 = solution.FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "good" });
            Assert.AreEqual(result2[0], 8);           
        }

        [TestMethod]
        public void IsPalindromeTest()
        {
            var solution = new Solution();

            Assert.IsTrue(solution.IsPalindrome("A man, a plan, a canal: Panama"));
            Assert.IsTrue(solution.IsPalindrome(" "));
            Assert.IsFalse(solution.IsPalindrome("race a car"));

        }
    }
}

