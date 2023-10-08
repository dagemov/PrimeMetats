using System;
using System.Collections.Generic;

namespace Path.Model;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? NameProduct { get; set; }

    public string? DescriptionProduct { get; set; }

    public int? IdCategory { get; set; }

    public decimal? Price { get; set; }

    public decimal? OferPrice { get; set; }

    public int? Stock { get; set; }

    public string? Imagen { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
