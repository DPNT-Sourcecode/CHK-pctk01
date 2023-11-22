using BeFaster.App.Solutions.CHK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Tests
{
    [TestClass]
    public class CheckoutSolutionTest
    {
        [TestMethod]
        public void ShouldFailWhenInputIsInvalid()
        {
            //Arrange
            string skus = "InvalidInput";
            int expected = -1;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldFailWhenInputIsEmptyString()
        {
            //Arrange
            string skus = "";
            int expected = 0;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldFailWhenItemIsNotPresent()
        {
            //Arrange
            string skus = "Z";
            int expected = -1;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturnPriceWithoutSpecialOfferPrice()
        {
            //Arrange
            string skus = "AA";
            int expected = 100;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        public void ShouldReturnPriceWithSpecialOfferPrice()
        {
            //Arrange
            string skus = "AAA";
            int expected = 130;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturnPriceWithSpecialOfferBestPrice()
        {
            //Arrange
            string skus = "AAAAA";
            int expected = 200;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturnPriceWithTwoDifferntSpecialOffersPrice()
        {
            //Arrange
            string skus = "AAAAAAAA";
            int expected = 330;
           
            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturnPriceWithTwoDifferntSpecialOffersPricePlusUnit()
        {
            //Arrange
            string skus = "AAAAAAAAA";
            int expected = 380;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturnPriceWithoutSpecialOfferItem()
        {
            //Arrange
            string skus = "EE";
            int expected = 80;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturnPriceWithSpecialOfferItem()
        {
            //Arrange
            string skus = "BBBEEEE";
            int expected = 190;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturnPriceWithSpecialOfferItemPay2Take3()
        {
            //Arrange
            string skus = "FFF";
            int expected = 20;

            //act
            var result = CheckoutSolution.ComputePrice(skus);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}

