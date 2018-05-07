using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialToolsCs.Tests
{
    using System.Linq;
    using Models;
    using Moq;

    [TestClass]
    public class UnitTest2
    {
        private Product[] products =
        {
            new Product { Name = "Kayak", Category = "Watersports", Price = 275M },
            new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
            new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
            new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M }
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            /*
            var discounter = new MinimumDiscountHelper();
            var target = new LinqValueCalculator(discounter);
            var goalTotal = products.Sum(e => e.Price);
            */
            var mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);

            var result = target.ValueProducts(products);

            // Assert.AreEqual(goalTotal, result);
            Assert.AreEqual(products.Sum(e => e.Price), result);
        }

        private Product[] CreateProduct(decimal value)
        {
            return new[] {new Product {Price = value}};
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Pass_Through_Variable_Discounts()
        {
            var mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0)))
                .Throws<ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100)))
                .Returns<decimal>(total => total * 0.9M);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
                .Returns<decimal>(total => total - 5);
            var target = new LinqValueCalculator(mock.Object);

            var FiveDollarDiscount = target.ValueProducts(CreateProduct(5));
            var TenDollarDiscount = target.ValueProducts(CreateProduct(10));
            var FiftyDollarDiscount = target.ValueProducts(CreateProduct(50));
            var HundredDollarDiscount = target.ValueProducts(CreateProduct(100));
            var FiveHundredDollarDiscount = target.ValueProducts(CreateProduct(500));

            Assert.AreEqual(5, FiveDollarDiscount, "$5 Fail");
            Assert.AreEqual(5, TenDollarDiscount, "$10 Fail");
            Assert.AreEqual(45, FiftyDollarDiscount, "$50 Fail");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 Fail");
            Assert.AreEqual(450, FiveHundredDollarDiscount, "$500 Fail");
            target.ValueProducts(CreateProduct(0));
        }
    }
}
