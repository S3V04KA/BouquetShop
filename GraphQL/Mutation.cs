using BouquetShop.Database;
using BouquetShop.Models;

namespace BouquetShop.GraphQL
{
    public class Mutation
    {
        public async Task<AddSalesmanPayload> AddSalesmanAsync(
            AddSalesmanInput input,
            [Service] ShopContext context)
        {
            var salesman = new Salesman
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                DateOfCreate = DateTime.Now,
                Emai = input.Email,
                Money = input.Money,
                Pass = input.Pass,
                PicUrl = input.PicUrl
            };

            context.salesmens.Add(salesman);
            await context.SaveChangesAsync();
            return new AddSalesmanPayload(salesman);
        }

        public async Task<AddBouqetPayload> AddBouqetAsync(
            AddBouqetInput input,
            [Service] ShopContext context)
        {
            var saleman = context.salesmens.Where<Salesman>(s => s.Id == input.SalemanId).First();

            if (saleman != null)
            {
                var bouqet = new Bouqet
                {
                    Name = input.Name,
                    Price = input.Price,
                    Salesman = saleman,
                    Count = input.Count
                };

                var bouquetInDb = context.bouqets.Add(bouqet).Entity;
                await context.SaveChangesAsync();
                saleman.Products.Add(bouquetInDb);
                await context.SaveChangesAsync();
                return new AddBouqetPayload(bouqet);
            }
            else
                return null;
        }

        public async Task<AddBuyerPayload> AddBuyerAsync(
            AddBuyerInput input,
            [Service] ShopContext context)
        {
            var buyer = new Buyer
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                DateOfCreate = DateTime.Now,
                Emai = input.Email,
                Money = input.Money,
                Pass = input.Pass,
                PicUrl = input.PicUrl
            };

            context.buyers.Add(buyer);
            await context.SaveChangesAsync();
            return new AddBuyerPayload(buyer);
        }

        public async Task<BouquetInCartPayload> AddBouqetToCartAsync(
            BouqetInCartInput input,
            [Service] ShopContext context)
        {
            var bouqet = context.bouqets.Where<Bouqet>(b => b.Id == input.BouqetId).FirstOrDefault();
            var buyer = context.buyers.Where<Buyer>(b => b.Id == input.BuyerId).FirstOrDefault();
            if(bouqet != null && buyer != null)
            {
                buyer.Cart.Add(bouqet);
            }

            return new BouquetInCartPayload(buyer.Cart);
        }

        public async Task<BouquetInCartPayload> RemoveBouqetFromCartAsync(
            BouqetInCartInput input,
            [Service] ShopContext context)
        {
            var buyer = context.buyers.Where<Buyer>(b => b.Id == input.BuyerId).FirstOrDefault();
            var bouqet = buyer.Cart.Where<Bouqet>(b => b.Id == input.BouqetId).FirstOrDefault();

            if (bouqet != null && buyer != null)
            {
                buyer.Cart.Remove(bouqet);
            }

            return new BouquetInCartPayload(buyer.Cart);
        }
    }
}
