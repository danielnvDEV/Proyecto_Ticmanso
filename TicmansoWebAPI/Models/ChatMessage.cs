namespace TicmansoWebAPI.Models
{
        public class ChatMessage
        {
            public long Id { get; set; }
            public long FromUserId { get; set; }
            public long ToUserId { get; set; }
            public string Message { get; set; }
            public DateTime CreatedDate { get; set; }
            public virtual User FromUser { get; set; }
            public virtual User ToUser { get; set; }
        }
    
}
