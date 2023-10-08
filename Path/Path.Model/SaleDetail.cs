using System;
using System.Collections.Generic;

namespace Path.Model;

public partial class SaleDetail
{
    public int IdSaleDetails { get; set; }

    public int? IdSale { get; set; }

    public int? Idproudct { get; set; }

    public int? Stock { get; set; }

    public decimal? Total { get; set; }

    public virtual Sale? IdSaleNavigation { get; set; }

    public virtual Product? IdproudctNavigation { get; set; }
}
