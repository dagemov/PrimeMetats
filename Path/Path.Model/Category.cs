using System;
using System.Collections.Generic;

namespace Path.Model;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? NameCategory { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
