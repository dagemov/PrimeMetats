using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.DTO
{
    public class CarDTO
    {
        public ProductDTO? product{ get; set; }
        public int? Stock { get; set; }
        public double? Price { get; set; }
        public decimal? Total{ get; set; }
    }
}
