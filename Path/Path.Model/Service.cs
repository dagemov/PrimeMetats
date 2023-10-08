using System;
using System.Collections.Generic;

namespace Path.Model;

public partial class Service
{
    public int IdService { get; set; }

    public int? IdUser { get; set; }

    public string? NameService { get; set; }

    public string? DescriptionService { get; set; }

    public decimal? Price { get; set; }

    public string? Imagen { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Lis> Lis { get; set; } = new List<Lis>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
