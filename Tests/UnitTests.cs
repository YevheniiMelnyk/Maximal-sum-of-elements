using MaxSumOfElements;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        private string _filePath = Path.Combine(@"D:\DataFile", "data.txt");

        [TestMethod]
        public void MaxSumCostructor_IsNotNull()
        {
            var maxSum = new MaxSum(_filePath);
            Assert.IsNotNull(maxSum);
        }

        [TestMethod]
        public void MaxSum_CheckSum()
        {
            var maxSum = new MaxSum(_filePath);
            var maxSumRowWithNumber = maxSum.GetMaxSumRowWithNumberDictionary();

            double expectedSum = 5.2;
            double actualSum = maxSumRowWithNumber.Values.First();

            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MaxSumCostructor_InvalidPath()
        {
            string filePath = Path.Combine(@"InvalidPath", "data.txt");
            var maxSum = new MaxSum(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MaxSumCostructor_NullArgument()
        {
            string? nullString = null;
            var maxSum = new MaxSum(nullString);
        }
    }
}