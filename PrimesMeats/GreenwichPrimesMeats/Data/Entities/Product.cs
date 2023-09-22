using System.ComponentModel.DataAnnotations;

namespace GreenwichPrimesMeats.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price{ get; set; }
    }
}
