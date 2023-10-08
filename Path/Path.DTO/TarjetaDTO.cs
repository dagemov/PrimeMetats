using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.DTO
{
    public class TarjetaDTO
    {
        [Required]
        public string TitularName { get; set; }
        [Required]
        public int number { get; set; }
        [Required]
        public DateTime expeditionDate { get; set; }
        [Required]
        public int CVV { get; set; }
    }
}
