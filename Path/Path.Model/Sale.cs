using System;
using System.Collections.Generic;

namespace Path.Model;

public partial class Sale
{
    public int IdSale { get; set; }

    public int? IdUser { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
