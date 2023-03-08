namespace HelloWorldTests
{
    [TestClass]
    public class HelloWorldTests
    {
        [TestMethod]
        public void HelloWorldButtonTests()
        { 
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void HelloWorldCalculationTests()
        {
            Assert.AreEqual(actual: 2, expected: 2);
        }
    }
}