namespace SportsStoreCs.Domain.Concrete
{
    using System.Data.Entity;
    using Entities;

    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}