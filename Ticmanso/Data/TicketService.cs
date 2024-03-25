using Microsoft.EntityFrameworkCore;
namespace Ticmanso.Data


{
    public class TicketService
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ViewTickets>> GetTicketsForView()
        {
            return await _dbContext.Tickets
                        .Include(t => t.CreationUser)
                        .Include(t => t.Priority)
                        .Include(t => t.Status)
                        .Select(t => new ViewTickets
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            creation_date = t.CreationDate.ToString("dd/MM/yyyy"),
                            chat_id = t.ChatId.ToString(),
                            creation_user = t.CreationUser.Name + " " + t.CreationUser.Surnames,
                            priority = t.Priority.Name,
                            status = t.Status.Name
                        })
                        .ToListAsync();
        }
    }


}
