using System.ComponentModel.DataAnnotations;

namespace GreenwichPrimesMeats.Models.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The field {0} Is required")]
        [EmailAddress(ErrorMessage = "you must input valid email")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The field {0} Is required")]
        [MinLength(6, ErrorMessage = "The field {0} must have min {1} chars")]
        public string Password { get; set; }

        [Display(Name = "Rememberme")]
        public bool RememberMe { get; set; }

    }
}
