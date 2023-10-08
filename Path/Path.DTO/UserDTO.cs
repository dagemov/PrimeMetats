using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage ="Input the full Name")]
        public string? NameUser { get; set; }
        [Required(ErrorMessage = "Input the Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Input a valid email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Input a Pass")]
        public string? Pass { get; set; }
        [Required(ErrorMessage = "Input the confirm pass")]
        public string? ConfirmPass { get; set; }
        public string? Rol { get; set; }

        public string? Imagen { get; set; }

        [MaxLength(10)]
        public int? PhoneNumber { get; set; }
      
    }
}
