using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Models;

public partial class TicketDTO
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? ChangedDate { get; set; }
    
    public DateTime? CloseDate { get; set; }

    public int? ChatId { get; set; }

    public long CreationUserId { get; set; }

    public long? SupportUserId { get; set; }

    public long PriorityId { get; set; }

    public int StatusId { get; set; }

}
