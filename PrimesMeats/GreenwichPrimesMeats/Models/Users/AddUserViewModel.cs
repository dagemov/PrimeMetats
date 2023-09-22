using GreenwichPrimesMeats.Enums;
using System.ComponentModel.DataAnnotations;

namespace GreenwichPrimesMeats.Models.Users
{
	public class AddUserViewModel: EditUserViewModel
	{
		[Display(Name = "Email")]
		[EmailAddress(ErrorMessage = "Input valid Email.")]
		[MaxLength(100, ErrorMessage = "The filed {0} Must have Max {1} chars")]
		[Required(ErrorMessage = "The field {0} Is required")]
		public string Username { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		[Required(ErrorMessage = "The field {0} Is required")]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "The field {0} Must have betwen {2} and {1} chars")]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "The Passwords Don't Macth")]
		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "The field {0} Is required.")]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "The field {0} Must have betwen {2} and {1} chars")]
		public string PasswordConfirm { get; set; }

		[Display(Name = "User Type")]
		public UserType UserType { get; set; }

	}
}
