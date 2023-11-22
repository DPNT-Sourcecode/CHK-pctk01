using BeFaster.App.Solutions.HLO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeFaster.App.Tests
{
    [TestClass]
    public class HelloSolutionTest
    {
        [TestMethod]
        public void ShouldReturnCorrectMessage()
        {
            //Arrenge
            var name = "John";
            var expected = "Hello, John!";

            //act
            var result = HelloSolution.Hello(name);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
