using System.Data.Entity;

namespace CoffeeShopWebsite.Models
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext() : base("CoffeeDbConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
