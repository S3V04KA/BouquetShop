namespace BouquetShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Emai { get; set; }
        public string Pass { get; set; }
        public string PicUrl { get; set; }
        public float Money { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}
