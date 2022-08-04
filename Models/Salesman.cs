namespace BouquetShop.Models
{
    public class Salesman : User
    {
        public ICollection<Bouqet> Products { get; set; }
    }
}
