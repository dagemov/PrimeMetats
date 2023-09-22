namespace GreenwichPrimesMeats.Data.Entities
{
    public class ServiceUser
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Service Service { get; set; }
    }
}
