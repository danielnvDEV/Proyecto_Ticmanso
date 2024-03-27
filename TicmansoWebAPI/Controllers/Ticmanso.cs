using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicmansoWebAPI.Models;
using TicmansoCrud.Shared; 
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Cors;

namespace TicmansoWebAPI.Controllers
{

    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class TicmansoController : ControllerBase
    {
        private readonly TicmansoProContext _dbContext;

        public TicmansoController(TicmansoProContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region User
        // GET: api/Users
        [HttpGet("users")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return await _dbContext.Users
                .Include(u => u.Role) 
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surnames = u.Surnames,
                    Mail = u.Mail,
                    CompanyId = u.CompanyId,
                    RoleId = u.Role.Id
                })
                .ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("users/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _dbContext.Users
                .Include(u => u.Role)
                .Where(u => u.Id == id)
                .Select(u => new UserDTO
                {
                   
                })
                .FirstOrDefaultAsync();

            if (user == null) return NotFound();

            return user;
        }

        // POST: api/Users
        [HttpPost("users")]
        [Produces("application/json")]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO UserDTO)
        {
            // Consider input validation and password hashing

            var user = new User
            {  
                Name = UserDTO.Name,
                Surnames = UserDTO.Surnames,
                Mail = UserDTO.Mail,
                Password = UserDTO.Password, 
                RoleId = UserDTO.RoleId,
                CompanyId = UserDTO.CompanyId,
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT: api/Users/5
        [HttpPut("users/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO UserDTO)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return NotFound();

            // Consider input validation and password hashing

            user.Name = UserDTO.Name;
            user.Surnames = UserDTO.Surnames;
            user.Mail = UserDTO.Mail;
            user.Password = UserDTO.Password;
            user.RoleId = UserDTO.RoleId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("users/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _dbContext.Users.FindAsync((int)id);
            if (user == null) return NotFound();

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

       
    }
}
