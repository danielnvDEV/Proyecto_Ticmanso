using System;
using System.Collections.Generic;
using TicmansoWebApiV2.Context;

namespace TicmansoWebApiV2.Context;


public partial class Priority
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; }
}
