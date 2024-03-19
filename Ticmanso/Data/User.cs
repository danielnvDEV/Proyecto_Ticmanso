using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Ticmanso.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }

        public Company Company { get; set; }
        public Role Role { get; set; }
        public ICollection<Signin> Signins { get; set; }
        public ICollection<Ticket> CreatedTickets { get; set; }
        public ICollection<Ticket> AssignedTickets { get; set; }
        public ICollection<Chat> CreatedChats { get; set; } // Propiedad "CreatedChats" añadida
        public ICollection<Chat> AssignedChats { get; set; } // Propiedad "CreatedChats" añadida

    }


}
