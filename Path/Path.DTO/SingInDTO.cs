using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.DTO
{
    public class SingInDTO
    {
        public int IdUser { get; set; }
        public string? NameUser { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string? Rol { get; set; }

        public string? Imagen { get; set; }

        [MaxLength(10)]
        public int? PhoneNumber { get; set; }
    }
}
