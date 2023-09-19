using System.ComponentModel.DataAnnotations;

namespace PrimesMeats.Models.Users
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "You must Input valid Email")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(6, ErrorMessage = "The field {0} must have min {1} chars")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}
