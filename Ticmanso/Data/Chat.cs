using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ticmanso.Data
{
    public class Chat
    {
        public int Id { get; set; }
        public string Messages { get; set; }
        public int CreationUserId { get; set; }
        public int? SupportUserId { get; set; }

        public Ticket Ticket { get; set; } // Propiedad "Ticket" añadida

        public User CreationUser { get; set; }
        public User SupportUser { get; set; }
    }
}
