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
    public class StatusController : ControllerBase
    {

        private readonly TicmansoDbContext _context;
        private readonly IConfiguration _configuration;
        public StatusController(TicmansoDbContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _configuration = configuration;
        }
        // GET: api/Status
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> GetStatuses()
        {
            return await _context.Statuses
                .Select(s => new StatusDTO
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<StatusDTO>> GetStatus(int id)
        {
            var status = await _context.Statuses
                .Where(s => s.Id == id)
                .Select(s => new StatusDTO
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .FirstOrDefaultAsync();

            if (status == null) return NotFound();

            return status;
        }

        // POST: api/Status
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<StatusDTO>> CreateStatus(StatusDTO statusDTO)
        {
            var status = new Status
            {
                Name = statusDTO.Name
            };

            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatus", new { id = status.Id }, new StatusDTO
            {
                Id = status.Id,
                Name = status.Name
            });
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateStatus(int id, StatusDTO statusDTO)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null) return NotFound();

            status.Name = statusDTO.Name;

            _context.Statuses.Update(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null) return NotFound();

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
