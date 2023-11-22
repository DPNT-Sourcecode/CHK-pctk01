using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeFaster.App.Solutions.SUM;
using System;

namespace BeFaster.App.Tests
{
    [TestClass]
    public class SumTest
    {
        [TestMethod]
        public void ShouldReturnCorrectSum()
        {
            //Arrenge
            int x = 1;
            int y = 2;
            int expect = 3;

            //act
            var result = SumSolution.Sum(x, y);

            //assert
            Assert.AreEqual(expect, result);
        }
    }
}


