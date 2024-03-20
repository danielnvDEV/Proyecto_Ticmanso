﻿using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Models;
public partial class Signing
{
    public DateTime Date { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime DepartureTime { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
