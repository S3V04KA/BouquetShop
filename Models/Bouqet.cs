namespace BouquetShop.Models
{
    public class Bouqet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }

        public int? SalesmanId { get; set; }
        public Salesman Salesman { get; set; }
        public ICollection<Buyer> Buyers { get; set; }
    }
}
