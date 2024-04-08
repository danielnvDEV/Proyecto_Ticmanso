using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Model;

/// <summary>
/// TRIAL
/// </summary>
public partial class Signing
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// TRIAL
    /// </summary>
    public DateTime EntryTime { get; set; }

    /// <summary>
    /// TRIAL
    /// </summary>
    public DateTime DepartureTime { get; set; }

    /// <summary>
    /// TRIAL
    /// </summary>
    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
