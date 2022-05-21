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

        [TestMethod]
        public void IsPalindromeNumberTest()
        {
            var solution = new Solution();

            Assert.IsTrue(solution.IsPalindrome(121));
            Assert.IsFalse(solution.IsPalindrome(123));
            Assert.IsFalse(solution.IsPalindrome(-121));
        }

        [TestMethod]
        public void IsMatchTest()
        {
            var solution = new Solution();

            Assert.IsTrue(solution.IsMatch("aa", "*"));
            Assert.IsTrue(solution.IsMatch("aa", "a*"));
            Assert.IsTrue(solution.IsMatch("adceb","*a*b"));
            Assert.IsFalse(solution.IsMatch("cb", "*a"));
            Assert.IsFalse(solution.IsMatch("ac", "ab*"));
            Assert.IsTrue(solution.IsMatch("", "********"));
            Assert.IsTrue(solution.IsMatch("abcabczzzde", "*abc???de*"));
            Assert.IsFalse(solution.IsMatch("acdcb", "a*c?b"));
            Assert.IsTrue(solution.IsMatch("aaaa", "***a"));
            Assert.IsFalse(solution.IsMatch("bcd", "??"));
            Assert.IsTrue(solution.IsMatch("c", "*?*"));
            Assert.IsFalse(solution.IsMatch("ab", "*a"));
            Assert.IsFalse(solution.IsMatch("abc", "*ab"));
            Assert.IsFalse(solution.IsMatch("abbbba", "a**a*?"));
            Assert.IsFalse(solution.IsMatch("mississippi", "m??*ss*?i*pi"));
            Assert.IsTrue(solution.IsMatch("ab", "*?*?*"));
            Assert.IsTrue(solution.IsMatch("abcde", "*?*?*?*?"));
            Assert.IsTrue(solution.IsMatch("ababbb", "**??a*"));
            Assert.IsTrue(solution.IsMatch("bbaa","*?*b*"));
            Assert.IsTrue(solution.IsMatch("xbya", "*b*a"));
            //Assert.IsFalse(solution.IsMatch("babbbbaabababaabbababaababaabbaabababbaaababbababaaaaaabbabaaaabababbabbababbbaaaababbbabbbbbbbbbbaabbb"
            //    ,"b**bb**a**bba*b**a*bbb**aba***babbb*aa****aabb*bbb***a"));
            //Assert.IsFalse(solution.IsMatch("abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb"
            //    , "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb"));
            //Assert.IsFalse(solution.IsMatch("aaaaaabbaabaaaaabababbabbaababbaabaababaaaaabaaaabaaaabababbbabbbbaabbababbbbababbaaababbbabbbaaaaaaabbaabbbbababbabbaaabababaaaabaaabaaabbbbbabaaabbbaabbbbbbbaabaaababaaaababbbbbaabaaabbabaabbaabbaaaaba"
            //   , "*bbb**a*******abb*b**a**bbbbaab*b*aaba*a*b**a*abb*aa****b*bb**abbbb*b**bbbabaa*b**ba**a**ba**b*a*a**aaa"));
            //Assert.IsFalse(solution.IsMatch("baaabbabbbaabbbbbbabbbaaabbaabbbbbaaaabbbbbabaaaaabbabbaabaaababaabaaabaaaabbabbbaabbbbbaababbbabaaabaabaaabbbaababaaabaaabaaaabbabaabbbabababbbbabbaaababbabbaabbaabbbbabaaabbababbabababbaabaabbaaabbba"
            //   ,"*b*ab*bb***abba*a**ab***b*aaa*a*b****a*b*bb**b**ab*ba**bb*bb*baab****bab*bbb**a*a*aab*b****b**ba**abba"));
            //Assert.IsFalse(solution.IsMatch("aabbbaabbabbbabbabbbaaabaaababbababaabbababaaaaabbaababbabaabbbaaabaaaabbbabaaabbabaaaaaaaababbaaaaabbbaabbabbaabbbbabbababbbabbbababbababaabaaabbababbababbbbaabaaababbbbbababbbbaaaaaaabbbabbbbbbabbaba"
            //    , "**a*abbbb*a*ba****ba**a**a*ba**a****aaa**abaa****aa**aaaa*bbbbbaaa*bb**aaabaaaa*aab*ab*aaabbb*b**a*aa*a"));
        }

        [TestMethod]
        public void UniquePathsWithObstaclesTest()
        {
            var solution = new Solution();

            var grid = new int[3][];
            grid[0] = new int[3] { 0, 0, 0 };
            grid[1] = new int[3] { 0, 1, 0 };
            grid[2] = new int[3] { 0, 0, 0 };
            Assert.AreEqual(2, solution.UniquePathsWithObstacles(grid));

            grid = new int[3][];
            grid[0] = new int[3] { 0, 0, 0 };
            grid[1] = new int[3] { 0, 0, 1 };
            grid[2] = new int[3] { 0, 0, 0 };
            Assert.AreEqual(3, solution.UniquePathsWithObstacles(grid));

            grid = new int[2][];
            grid[0] = new int[2] { 0, 0 };
            grid[1] = new int[2] { 0, 1 };            
            Assert.AreEqual(0, solution.UniquePathsWithObstacles(grid));

            grid = new int[29][];
            grid[0] = new int[18] { 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
            grid[1] = new int[18] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0 };
            grid[2] = new int[18] { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1 };
            grid[3] = new int[18] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            grid[4] = new int[18] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            grid[5] = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0 };
            grid[6] = new int[18] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0 };
            grid[7] = new int[18] { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
            grid[8] = new int[18] { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 };

            grid[9] = new int[18] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
            grid[10] = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            grid[11] = new int[18] { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 };
            grid[12] = new int[18] { 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
            grid[13] = new int[18] { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };
            grid[14] = new int[18] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 };
            grid[15] = new int[18] { 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            grid[16] = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };


            grid[17] = new int[18] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0 };
            grid[18] = new int[18] { 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0 };
            grid[19] = new int[18] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            grid[20] = new int[18] { 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 };
            grid[21] = new int[18] { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 0, 0 };
            grid[22] = new int[18] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1 };
            grid[23] = new int[18] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
            grid[24] = new int[18] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            grid[25] = new int[18] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            grid[26] = new int[18] { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 };
            grid[27] = new int[18] { 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1 };
            grid[28] = new int[18] { 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };

            Assert.AreEqual(13594824, solution.UniquePathsWithObstacles(grid));
        }
    }
}

