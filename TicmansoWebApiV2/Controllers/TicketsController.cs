using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicmansoV2.Shared;
using TicmansoWebApiV2;
using TicmansoWebApiV2.Context;

namespace TicmansoV2.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TicmansoDbContext _context;
        private readonly IConfiguration _configuration;

        public TicketsController(TicmansoDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDTO>>> GetTickets()
        {
            return await _context.Tickets
               .Select(t => new TicketDTO
               {
                   Id = t.Id,
                   Title = t.Title,
                   Description = t.Description,
                   CreationDate = t.CreationDate,
                   ChangedDate = t.ChangedDate,
                   CloseDate = t.CloseDate,
                   CreationUserId = t.CreationUserId,
                   SupportUserId = t.SupportUserId ?? null,
                   PriorityId = t.PriorityId,
                   StatusId = t.StatusId
               }).ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDTO>> GetTicket(int id)
        {
            var ticket = await _context.Tickets
               .Where(t => t.Id == id)
               .Select(t => new TicketDTO
               {
                   Id = t.Id,
                   Title = t.Title,
                   Description = t.Description,
                   CreationDate = t.CreationDate,
                   ChangedDate = t.ChangedDate,
                   CloseDate = t.CloseDate,
                   CreationUserId = t.CreationUserId,
                   SupportUserId = t.SupportUserId ?? null,
                   PriorityId = t.PriorityId,
                   StatusId = t.StatusId
               })
               .FirstOrDefaultAsync();

            if (ticket == null) return NotFound();

            return ticket;
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult<IEnumerable<TicketDTO>>> GetTickets(string userId)
        {
            var tickets = await _context.Tickets
                .Where(t => t.CreationUserId == userId)
                .Select(t=>new TicketDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreationDate = t.CreationDate,
                    ChangedDate = t.ChangedDate,
                    CloseDate = t.CloseDate,
                    CreationUserId = t.CreationUserId,
                    SupportUserId = t.SupportUserId ?? null,
                    PriorityId = t.PriorityId,
                    StatusId = t.StatusId
                })
                .ToListAsync();

            return tickets;
        }

        [HttpGet("last5")]
        public async Task<ActionResult<IEnumerable<TicketDTO>>> GetLast5Tickets()
        {
            var tickets = await _context.Tickets
                .OrderByDescending(t => t.CreationDate)
                .Take(5)
                .Select(t => new TicketDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreationDate = t.CreationDate,
                    ChangedDate = t.ChangedDate,
                    CloseDate = t.CloseDate,
                    CreationUserId = t.CreationUserId,
                    SupportUserId = t.SupportUserId ?? null,
                    PriorityId = t.PriorityId,
                    StatusId = t.StatusId
                })
                .ToListAsync();

            return tickets;
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, TicketDTO ticketDTO)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            ticket.Title = ticketDTO.Title;
            ticket.Description = ticketDTO.Description;
            ticket.ChangedDate = ticketDTO.ChangedDate;
            ticket.CloseDate = ticketDTO.CloseDate ?? ticket.CloseDate; ;
            ticket.CreationUserId = ticketDTO.CreationUserId;
            ticket.SupportUserId = ticketDTO.SupportUserId ?? null;
            ticket.PriorityId = ticketDTO.PriorityId;
            ticket.StatusId = ticketDTO.StatusId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(TicketDTO ticketDTO)
        {
            var ticket = new Ticket
            {
                Title = ticketDTO.Title,
                Description = ticketDTO.Description,
                CreationDate = ticketDTO.CreationDate,
                ChangedDate = ticketDTO.ChangedDate ?? ticketDTO.ChangedDate,
                CloseDate = ticketDTO.CloseDate ?? ticketDTO.CloseDate,
                CreationUserId = ticketDTO.CreationUserId,
                PriorityId = ticketDTO.PriorityId,
                StatusId = ticketDTO.StatusId
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }

}
