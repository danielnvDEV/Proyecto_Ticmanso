﻿using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Models;

public partial class Chat
{
    public int Id { get; set; }

    public string? Messages { get; set; }

    public long UserId { get; set; }

    public long UserId1 { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual User User { get; set; } = null!;

    public virtual User UserId1Navigation { get; set; } = null!;
}