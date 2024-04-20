namespace TicmansoWebApiV2.Context
{
    public class Attendance
    {
        public DateTime Date { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public double EntryLatitude { get; set; }
        public double EntryLongitude { get; set; }
        public double? DepartureLatitude { get; set; }
        public double? DepartureLongitude { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
