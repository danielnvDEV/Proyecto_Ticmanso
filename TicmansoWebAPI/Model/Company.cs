using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Model;

/// <summary>
/// TRIAL
/// </summary>
public partial class Company
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// TRIAL
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// TRIAL
    /// </summary>
    public string Country { get; set; } = null!;

    /// <summary>
    /// TRIAL
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// TRIAL
    /// </summary>
    public long PostalCode { get; set; }

    /// <summary>
    /// TRIAL
    /// </summary>
    public string City { get; set; } = null!;

    /// <summary>
    /// TRIAL
    /// </summary>
    public string Cif { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
