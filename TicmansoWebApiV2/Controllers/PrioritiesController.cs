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
    public class PriorityController : ControllerBase
    {

        private readonly TicmansoDbContext _context;
        private readonly IConfiguration _configuration;
        public PriorityController(TicmansoDbContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _configuration = configuration;
        }
        // GET: api/Priority
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<PriorityDTO>>> GetPriorityes()
        {
            return await _context.Priorities
                .Select(s => new PriorityDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Color = s.Color,
                })
                .ToListAsync();
        }

        // GET: api/Priority/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<PriorityDTO>> GetPriority(int id)
        {
            var Priority = await _context.Priorities
                .Where(s => s.Id == id)
                .Select(s => new PriorityDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Color = s.Color,
                })
                .FirstOrDefaultAsync();

            if (Priority == null) return NotFound();

            return Priority;
        }

        // POST: api/Priority
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PriorityDTO>> CreatePriority(PriorityDTO PriorityDTO)
        {
            var priority = new Priority
            {
                Name = PriorityDTO.Name, 
                Color = PriorityDTO.Color
            };

            _context.Priorities.Add(priority);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPriority", new { id = priority.Id }, new PriorityDTO
            {
                Id = priority.Id,
                Name = priority.Name,
                Color = priority.Color,
            });
        }

        // PUT: api/Priority/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePriority(int id, PriorityDTO PriorityDTO)
        {
            var Priority = await _context.Priorities.FindAsync(id);
            if (Priority == null) return NotFound();

            Priority.Name = PriorityDTO.Name;
            Priority.Color = PriorityDTO.Color;

            _context.Priorities.Update(Priority);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Priority/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletePriority(int id)
        {
            var Priority = await _context.Priorities.FindAsync(id);
            if (Priority == null) return NotFound();

            _context.Priorities.Remove(Priority);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
