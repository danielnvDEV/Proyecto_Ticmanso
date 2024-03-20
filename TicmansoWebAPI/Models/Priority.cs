﻿using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Models;


public partial class Priority
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
