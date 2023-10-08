using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.DTO
{
    public class SaleDetailDTO
    {
        public int IdSaleDetails { get; set; }

        public int? IdSale { get; set; }

        public int? Idproudct { get; set; }

        public int? Stock { get; set; }

        public decimal? Total { get; set; }

    }
}
