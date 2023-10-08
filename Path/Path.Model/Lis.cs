using System;
using System.Collections.Generic;

namespace Path.Model;

public partial class Lis
{
    public int IdLis { get; set; }

    public int? IdSerivce { get; set; }

    public string? Title { get; set; }

    public string? Context { get; set; }

    public string? Exeptions { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Service? IdSerivceNavigation { get; set; }
}
