namespace TicmansoWebApiV2.Context
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? TicketId { get; set; }
        public DateTime Timestamp { get; set; }

        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public string? ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }

}
