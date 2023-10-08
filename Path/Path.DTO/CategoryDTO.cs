using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.DTO
{
    public class CategoryDTO
    {

        public int IdCategory { get; set; }
        [Required]
        public string? NameCategory { get; set; }

    }
}
