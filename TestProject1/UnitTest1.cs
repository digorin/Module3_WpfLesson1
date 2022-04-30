using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppForTest;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int actual = Program.Sum(2, 2);
            int expected = 4;
            Assert.AreEqual(actual, expected);
        }
    }
}