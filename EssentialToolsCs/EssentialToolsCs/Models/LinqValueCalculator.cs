namespace EssentialToolsCs.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class LinqValueCalculator : IValueCalculator
    {
        private readonly IDiscountHelper discounter;

        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            // return products.Sum(p => p.Price);
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}