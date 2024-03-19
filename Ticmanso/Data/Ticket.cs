using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Ticmanso.Data
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangedDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int ChatId { get; set; }
        public int CreationUserId { get; set; }
        public int? SupportUserId { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }

        public Chat Chat { get; set; }
        public User CreationUser { get; set; }
        public User SupportUser { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }


}
