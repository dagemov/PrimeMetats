using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Path.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string? NameUser { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Pass { get; set; }

    public string? Rol { get; set; }

    public string? Imagen { get; set; }

    [MaxLength(10)]
    public int? PhoneNumber { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
