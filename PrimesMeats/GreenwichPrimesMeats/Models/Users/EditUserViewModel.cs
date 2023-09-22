using GreenwichPrimesMeats.Data.Entities;
using GreenwichPrimesMeats.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GreenwichPrimesMeats.Models.Users
{
	public class EditUserViewModel
	{
        
		public string Id { get; set; }

		[Display(Name = "First Name")]
		public string Name { get; set; }
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Display(Name = "Picture")]
		public Guid ImageId { get; set; }

		[Display(Name = "Picture")]
		public string ImageFullPath => ImageId == Guid.Empty
			? $"https://localhost:7263/images/noimage.png"
			: $"https://shoping1.blob.core.windows.net/users/{ImageId}";
		[Display(Name = "Image")]
		public IFormFile? ImageFile { get; set; }
		[Display(Name = "User type")]
		public UserType UserType { get; set; }
		[Display(Name = "User")]
		public string FullName => $"{Name} {LastName}";

		[Display(Name = "Phone")]
		[MaxLength(20)]
		[Required()]
		public string PhoneNumber { get; set; }
		public string Street { get; set; }

        public int ZipCode { get; set; }
        


    }
}
