using Microsoft.AspNetCore.Identity;

namespace TicmansoWebApiV2.Context
{
    public class ApplicationUser : IdentityUser
    {

        public Company? Company { get; set; }
        public ICollection<Ticket> CreatedTickets { get; set; }
        public ICollection<Ticket> SupportedTickets { get; set; }
        public string Name { get; internal set; }
    }
}

