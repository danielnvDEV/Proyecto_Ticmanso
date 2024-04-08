using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Models;


public partial class User : IdentityUser
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Surnames { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long CompanyId { get; set; }

    public long RoleId { get; set; }

    public virtual ICollection<Chat> ChatUserId1Navigations { get; set; } = new List<Chat>();

    public virtual ICollection<Chat> ChatUsers { get; set; } = new List<Chat>();

    public virtual Company Company { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Signing> Signings { get; set; } = new List<Signing>();

    public virtual ICollection<Ticket> TicketCreationUsers { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketSupportUsers { get; set; } = new List<Ticket>();
}
