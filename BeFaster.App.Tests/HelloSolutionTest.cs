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
            var expected = "Hello World.";

            //act
            var result = HelloSolution.Hello("");

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}

