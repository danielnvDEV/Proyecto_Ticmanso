
namespace TicmansoWebApiV2.Context
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangedDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public string CreationUserId { get; set; }
        public ApplicationUser CreationUser { get; set; }

        public string? SupportUserId { get; set; }
        public ApplicationUser? SupportUser { get; set; }
    }
}
