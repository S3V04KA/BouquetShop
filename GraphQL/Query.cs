using BouquetShop.Database;
using BouquetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BouquetShop.GraphQL
{
    public class Query
    {
        public IQueryable<Bouqet> GetBouqets([Service] ShopContext context)
        {
            return context.bouqets.Include(b => b.Salesman).Include(b => b.Buyers).AsQueryable<Bouqet>();
        }

        public IQueryable<Salesman> GetSalesmans([Service] ShopContext context)
        {
            return context.salesmens.Include(s => s.Products);
        }

        public IQueryable<Buyer> GetBuyers([Service] ShopContext context)
        {
            return context.buyers.Include(b => b.Cart);
        }

        public IQueryable<Bouqet> GetBouqetsBySalemanId([Service] ShopContext context, int id)
        {
            var salesman = context.salesmens.Where<Salesman>(s => s.Id == id).Include(s => s.Products).First();
            Console.WriteLine(salesman.FirstName);
            if (salesman != null)
                return salesman.Products.AsQueryable();
            else
                return null;
        }

        public IQueryable<Bouqet> GetBuyersCartById([Service] ShopContext context, int id)
        {
            var buyer = context.buyers.Where<Buyer>(b => b.Id == id).Include(b => b.Cart).First();
            if (buyer != null)
                return buyer.Cart.AsQueryable();
            else
                return null;
        }
    }
}
