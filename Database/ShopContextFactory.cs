using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BouquetShop.Database
{
    public class ShopContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        public ShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();

            optionsBuilder.UseSqlite(@"Data Source=./Shop.db");

            return new ShopContext(optionsBuilder.Options);
        }
    }
}
