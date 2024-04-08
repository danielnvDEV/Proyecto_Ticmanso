using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Model;

/// <summary>
/// TRIAL
/// </summary>
public partial class Priority
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
