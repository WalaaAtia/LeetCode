using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwoSum;

namespace TwoSumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SolutionTest()
        {
            var solution = new Solution();

            var result = (solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9));

            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 1);


            var result2 = (solution.TwoSum(new int[] { -6, 7, 11, 15 }, 9));

            Assert.AreEqual(result2[0], 0);
            Assert.AreEqual(result2[1], 3);

        }
    }
}
