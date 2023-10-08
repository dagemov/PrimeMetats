using GreenwichPrimesMeats.Data.Entities;
using GreenwichPrimesMeats.Enums;
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
        [Display(Name = "Status service")]
        public ServiceStatus ServiceStatus { get; set; }
     
        [Display(Name = "Extimate Price")]
        public double PriceService { get; set; }

        public  string UserId { get; set; }

        public Lis Lis { get; set; }
        public Schedule Schedule { get; set; }
        public DateTime DateTimeCreation { get; set; }
    }
}
