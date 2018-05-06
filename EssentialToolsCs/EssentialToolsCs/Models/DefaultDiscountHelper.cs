namespace EssentialToolsCs.Models
{
    public class DefaultDiscountHelper : IDiscountHelper
    {
        // property injection
        // public decimal DiscountSize { get; set; }

        // constructor injection
        private readonly decimal discountSize;

        public DefaultDiscountHelper(decimal discountParam)
        {
            discountSize = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            // return (totalParam - (10m / 100m * totalParam));
            // property injection
            // return (totalParam - (DiscountSize / 100m * totalParam));
            // constructor injection
            return (totalParam - (discountSize / 100m * totalParam));
        }
    }
}