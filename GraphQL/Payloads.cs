using BouquetShop.Models;

namespace BouquetShop.GraphQL
{
    public class AddSalesmanPayload
    {
        public AddSalesmanPayload(Salesman salesman)
        {
            Salesman = salesman;
        }

        public Salesman Salesman { get; set; }
    }

    public class AddBuyerPayload
    {
        public AddBuyerPayload(Buyer buyer)
        {
            Buyer = buyer;
        }

        public Buyer Buyer { get; set; }
    }

    public class AddBouqetPayload
    {
        public AddBouqetPayload(Bouqet bouqet)
        {
            Bouqet = bouqet;
        }

        public Bouqet Bouqet { get; set; }
    }

    public class BouquetInCartPayload
    {
        public BouquetInCartPayload(ICollection<Bouqet> cart)
        {
            Cart = cart;
        }

        public ICollection<Bouqet> Cart { get; set; }
    }
}
