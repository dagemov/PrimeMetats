namespace GreenwichPrimesMeats.Data.Entities
{
    public class CreditClients
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
        public double TotalCredit { get; set; }
    }
}
