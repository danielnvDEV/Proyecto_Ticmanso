using System;
using System.Collections.Generic;

namespace TicmansoWebAPI.Models;

public partial class GeneralViewTicket
{
    public long NumTicket { get; set; }

    public string Tittle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string CreationUser { get; set; } = null!;

    public string? Status { get; set; }

    public string Priority { get; set; } = null!;

    public string SuportUser { get; set; } = null!;
}
