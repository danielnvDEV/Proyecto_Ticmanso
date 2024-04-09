using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Model;

/// <summary>
/// TRIAL
/// </summary>
public partial class User : AspNetUser
{
    public string? Surnames { get; set; }

    public long CompanyId { get; set; }

    public long RoleId { get; set; }

    public virtual ICollection<Chat> ChatUserId1Navigations { get; set; } = new List<Chat>();

    public virtual ICollection<Chat> ChatUsers { get; set; } = new List<Chat>();

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Signing> Signings { get; set; } = new List<Signing>();

    public virtual ICollection<Ticket> TicketCreationUsers { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketSupportUsers { get; set; } = new List<Ticket>();
}
