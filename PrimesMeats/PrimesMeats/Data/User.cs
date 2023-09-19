using Microsoft.AspNetCore.Identity;
using PrimesMeats.Enums;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PrimesMeats.Data
{
    public class User : IdentityUser
    {
        [Display(Name = "Names")]
        [MaxLength(50, ErrorMessage = "The block {0} Need maxim at  {1} caracters.")]
        [Required(ErrorMessage = "The block {0} is Required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Names")]
        [MaxLength(50, ErrorMessage = "The block {0} Need maxim at  {1} caracters.")]
        [Required(ErrorMessage = "The block {0} is Required.")]
        public string LastName { get; set; }

        [Display(Name = "Picture")]
        public Guid ImageId { get; set; }

        [Display(Name = "Picture")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7107/Images/Users/no-image.jpg"
            : $"https://pathv1.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "User type")]
        public UserType UserType { get; set; }
        [Display(Name = "User")]
        public string FullName => $"{FirstName} {LastName}";


    }
}
