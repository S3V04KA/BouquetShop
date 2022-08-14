using BouquetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BouquetShop.Database
{
    public class ShopContext : DbContext
    {
        public DbSet<Bouqet> bouqets { get; set; }
        public DbSet<Salesman> salesmens { get; set; }
        public DbSet<Buyer> buyers { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bouqet>().
                HasOne(b => b.Salesman).
                WithMany(s => s.Products);
        }
    }
}
