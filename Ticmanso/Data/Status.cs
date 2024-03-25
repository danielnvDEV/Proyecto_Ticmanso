using System.ComponentModel.DataAnnotations;

namespace Ticmanso.Data
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }

}
