using GreenwichPrimesMeats.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace GreenwichPrimesMeats.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "First Name")]
        public string Name { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Picture")]
        public Guid ImageId { get; set; }

        [Display(Name = "Picture")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7263/images/users/no-image.jpg"
            : $"https://pathv1.blob.core.windows.net/users/{ImageId}";
        [Display(Name = "User type")]
        public UserType UserType { get; set; }
        [Display(Name = "User")]
        public string FullName => $"{Name} {LastName}";

        [MaxLength(100)]
        public string Street { get; set; }
        [MaxLength(6)]
        public int ZipCode { get; set; }
        public ICollection<CreditClients> CreditClients { get; set; }
        public ICollection<Phone> Phones { set; get; }
        public ICollection<WeekNominal> WeekNominals { set; get;}
        public ICollection<ServiceUser> Services { set; get; }
        public DateTime DateTimeCreation { get; set; }
    }
}
