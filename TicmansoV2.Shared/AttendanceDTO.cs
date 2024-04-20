using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicmansoV2.Shared
{
    public class AttendanceDTO
    {
        public DateTime Date { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public string UserId { get; set; }
        public double EntryLatitude { get; set; }
        public double EntryLongitude { get; set; }
        public double? DepartureLatitude { get; set; }
        public double? DepartureLongitude { get; set; }
    }
}
