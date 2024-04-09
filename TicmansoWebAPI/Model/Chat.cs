using TicmansoWebAPI.Identity;

namespace TicmansoWebAPI.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
        public int? TicketId { get; set; }

        public virtual ApplicationUser User1 { get; set; }
        public virtual ApplicationUser User2 { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
