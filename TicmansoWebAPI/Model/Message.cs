using TicmansoWebAPI.Identity;

namespace TicmansoWebAPI.Model
{
    public class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string SenderId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Chat Chat { get; set; }
        public virtual ApplicationUser Sender { get; set; }
    }
}
