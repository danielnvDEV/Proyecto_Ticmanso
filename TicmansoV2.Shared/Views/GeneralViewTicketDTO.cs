using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicmansoV2.Shared.Views
{
    public class GeneralViewTicketDTO
    {
        public int NumTicket { get; set; }

        public string Tittle { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CreationUser { get; set; } = null!;

        public string Status { get; set; }

        public string Priority { get; set; } = null!;

        public string? SuportUser { get; set; } = null!;
    }
}
