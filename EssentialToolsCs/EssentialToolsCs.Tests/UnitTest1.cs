using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialToolsCs.Tests
{
    using Models;

    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper GetTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            var target = GetTestObject();
            decimal total = 200;

            var discountedTotal = target.ApplyDiscount(total);

            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            var target = GetTestObject();

            var TenDollarDiscount = target.ApplyDiscount(10);
            var HundredDollarDiscount = target.ApplyDiscount(100);
            var FiftyDollarDiscount = target.ApplyDiscount(50);

            Assert.AreEqual(5M, TenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95M, HundredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45M, FiftyDollarDiscount, "$50 discount is wrong");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            var target = GetTestObject();

            var discount5 = target.ApplyDiscount(5);
            var discount0 = target.ApplyDiscount(0);

            Assert.AreEqual(5M, discount5);
            Assert.AreEqual(0M, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            var target = GetTestObject();

            target.ApplyDiscount(-5);
        }
    }
}
