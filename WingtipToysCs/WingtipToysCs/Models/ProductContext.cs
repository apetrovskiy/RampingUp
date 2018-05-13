namespace WingtipToysCs.Models
{
    using System.Data.Entity;
    public class ProductContext : DbContext
    {
        public ProductContext() : base("WingtipToysCs")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}