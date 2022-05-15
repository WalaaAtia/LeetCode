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
    }
}
