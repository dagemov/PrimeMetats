using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.DTO
{
    public class SaleDTO
    {
        public int IdSale { get; set; }

        public int? IdUser { get; set; }

        public decimal? Total { get; set; }


        public virtual ICollection<SaleDetailDTO> SaleDetails { get; set; } = new List<SaleDetailDTO>();
    }
}
