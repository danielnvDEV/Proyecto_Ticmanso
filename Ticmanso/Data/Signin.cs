using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ticmanso.Data
{
    public class Signin
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int UserId { get; set; } // Propiedad "UserId" añadida

        public User User { get; set; }
    }


}
