using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicmansoV2.Shared
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangedDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int PriorityId { get; set; }     
        public int StatusId { get; set; }       
        public string CreationUserId { get; set; }     
        public string? SupportUserId { get; set; }        
    }
}
