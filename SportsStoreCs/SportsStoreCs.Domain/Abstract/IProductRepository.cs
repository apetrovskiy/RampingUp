namespace SportsStoreCs.Domain.Abstract
{
    using System.Collections.Generic;
    using Entities;

    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}