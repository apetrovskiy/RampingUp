namespace EssentialToolsCs.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        private readonly IValueCalculator calc;

        public ShoppingCart(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}