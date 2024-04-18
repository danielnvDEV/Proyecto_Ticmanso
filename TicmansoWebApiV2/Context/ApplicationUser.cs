using Microsoft.AspNetCore.Identity;

namespace TicmansoWebApiV2.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; internal set; }
        public int? Companyid { get; internal set; }
        public virtual Company? Company { get; set; }
        public virtual ICollection<Ticket> CreatedTickets { get; set; }
        public virtual ICollection<Ticket> SupportedTickets { get; set; }

    }
}

