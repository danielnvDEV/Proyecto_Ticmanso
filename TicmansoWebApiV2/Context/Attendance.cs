namespace TicmansoWebApiV2.Context
{
    public class Attendance
    {
        public DateTime Date { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
