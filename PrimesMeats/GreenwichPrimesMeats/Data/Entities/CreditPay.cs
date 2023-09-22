namespace GreenwichPrimesMeats.Data.Entities
{
    public class CreditPay
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public User Users { get; set; }
    }
}
