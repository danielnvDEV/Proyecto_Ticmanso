using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicmansoWebApiV2.Context;
using TicmansoV2.Shared.Views;
using Microsoft.EntityFrameworkCore;

namespace TicmansoWebApiV2.Controllers.Views
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralTiketsController : ControllerBase
    {
        private readonly TicmansoDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public GeneralTiketsController(TicmansoDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<GeneralViewTicketDTO>>> GetGeneralViewTickets()
        {
            return await _dbContext.Tickets
                .Select(t => new GeneralViewTicketDTO
                {
                    NumTicket = t.Id,
                    Tittle = t.Title,
                    Description = t.Description,
                    CreationUser = t.CreationUser.Name,
                    SuportUser = t.SupportUser.Name,
                    Status = t.Status.Name,
                    Priority = t.Priority.Name,

                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<GeneralViewTicketDTO>> GetGeneralViewTicket(int id)
        {
            var ticket = await _dbContext.Tickets
                .Where(t => t.Id == id)
                .Select(t => new GeneralViewTicketDTO
                {
                    NumTicket = t.Id,
                    Tittle = t.Title,
                    Description = t.Description,
                    CreationUser = t.CreationUser.Name,
                    SuportUser = t.SupportUser.Name,
                    Status = t.Status.Name,
                    Priority = t.Priority.Name,

                })
                .FirstOrDefaultAsync();

            if (ticket == null) return NotFound();

            return ticket;
        }
    }
}
