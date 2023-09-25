using System.ComponentModel.DataAnnotations;

namespace GreenwichPrimesMeats.Models.Users
{
    public class ServiceUserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Type Service")]
        public string Type { get; set; }

        [Display(Name = "Description Type")]
        public string TypeDescription { get; set; }
        [Display(Name = "Extimate Price")]
        public double PriceService { get; set; }
        public  string UserId { get; set; }
    }
}
