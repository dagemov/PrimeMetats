using System.ComponentModel.DataAnnotations;

namespace GreenwichPrimesMeats.Data.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        [Required]
        public int Phone1{ get; set; }
        public int Phone2 { get; set; }
        public int Phone3 { get;}
    }
}
