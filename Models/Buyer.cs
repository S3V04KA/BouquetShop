namespace BouquetShop.Models
{
    public class Buyer : User
    {
        public ICollection<Bouqet> Cart { get; set; }
    }
}
