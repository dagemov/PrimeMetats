using GreenwichPrimesMeats.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace GreenwichPrimesMeats.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }

        [Display(Name = "Name Service")]
        public string Name { get; set; }
        public string Description { get; set; }


        [Display(Name = "Status")]
        public ServiceStatus Type { get; set; }

        [Display(Name = "Price Extimate")]       
        public double PriceService { get; set; }

        public ICollection<ServiceUser> ServiceUsers { get; set; }
        public Lis Lis { get; set; }
        public Schedule Schedule { get; set; }
        public DateTime DateTimeCreation { get; set; }
    }
}
