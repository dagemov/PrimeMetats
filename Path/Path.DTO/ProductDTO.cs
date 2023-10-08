using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.DTO
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }
        [Required]
        public string? NameProduct { get; set; }
        [Required]
        public string? DescriptionProduct { get; set; }

        public int? IdCategory { get; set; }
        [Required]
        public decimal? Price { get; set; }

        public decimal? OferPrice { get; set; }

        public int? Stock { get; set; }

        public string? Imagen { get; set; }
        public virtual CategoryDTO? IdCategoryNavigation { get; set; }
    }
}
