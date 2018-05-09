namespace SportsStoreCs.Domain.Concrete
{
    using System.Collections.Generic;
    using Abstract;
    using Entities;

    public class EFProductRepository : IProductRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products;}
        }
    }
}