using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Models;


public partial class Company
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Address { get; set; } = null!;

    public long PostalCode { get; set; }

    public string City { get; set; } = null!;

    public string Cif { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
