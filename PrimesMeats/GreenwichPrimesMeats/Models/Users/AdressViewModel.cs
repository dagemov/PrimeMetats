namespace GreenwichPrimesMeats.Models.Users
{
    public class AdressViewModel
    {
        public int Id { get; set; }
        public string NameStreet { get; set; }
        public int ZipCode { get; set; }
        public Guid UserId { get; set; }
    }
}
