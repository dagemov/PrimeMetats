using System.ComponentModel.DataAnnotations;

namespace GreenwichPrimesMeats.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
