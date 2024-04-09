using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Model;

/// <summary>
/// TRIAL
/// </summary>
public partial class Ticket
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? ChangedDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public int? ChatId { get; set; }

    public long PriorityId { get; set; }

    public int StatusId { get; set; }

    public string AspNetUserCreationId { get; set; }

    public string AspNetUserSupportId { get; set; }

    public virtual Chat? Chat { get; set; }

    public virtual User CreationUser { get; set; } = null!;

    public virtual Priority Priority { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual User? SupportUser { get; set; }
}
