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
        [Tags("Users")]
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
                    Password = u.Password,
                    CompanyId = u.CompanyId,
                    RoleId = u.Role.Id
                })
                .ToListAsync();
        }

        // GET: api/Users/5
        [Tags("Users")]
        [HttpGet("users/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _dbContext.Users
                .Include(u => u.Role)
                .Where(u => u.Id == id)
                .Select(u => new UserDTO
                {
                    Name = u.Name,
                    Surnames = u.Surnames,
                    Mail = u.Mail,
                    CompanyId = u.CompanyId,
                    RoleId = u.Role.Id
                })
                .FirstOrDefaultAsync();

            if (user == null) return NotFound();

            return user;
        }

        // POST: api/Users
        [Tags("Users")]
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
        [Tags("Users")]
        [HttpPut("users/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUser(long id, UserDTO UserDTO)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return NotFound();

            
            user.Id = id;
            user.Name = UserDTO.Name;
            user.Surnames = UserDTO.Surnames;
            user.Mail = UserDTO.Mail;
            user.Password = UserDTO.Password;
            user.RoleId = UserDTO.RoleId;

            _dbContext.Users.Update(user);

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Users/id
        [Tags("Users")]
        [HttpDelete("users/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid user ID.");
            }
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            try
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return Conflict("A concurrency error occurred. The user may have been modified or deleted.");
            }
        }
        #endregion

        #region Role
        [Tags("Role")]
        [HttpGet("role")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRole()
        {
            return await _dbContext.Roles
                .Select(u => new RoleDTO
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .ToListAsync();
        }
        [Tags("Role")]
        [HttpGet("role/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<RoleDTO>> GetRole(long id)
        {
            var role = await _dbContext.Roles
                .Where(u => u.Id == id)
                .Select(u => new RoleDTO
                {
                    Id = u.Id,
                    Name = u.Name,

                })
                .FirstOrDefaultAsync();

            if (role == null) return NotFound();

            return role;
        }

        #endregion

        #region Status
        [Tags("Status")]
        [HttpGet("status")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> GetStatus()
        {
            return await _dbContext.Statuses
                .Select(u => new StatusDTO
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .ToListAsync();
        }

        [Tags("Status")]
        [HttpGet("status/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<StatusDTO>> GetStatus(long id)
        {
            var status = await _dbContext.Statuses
                .Where(u => u.Id == id)
                .Select(u => new StatusDTO
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .FirstOrDefaultAsync();

            if (status == null) return NotFound();

            return status;
        }

        #endregion

        #region Company
        [Tags("Company")]
        [HttpGet("company")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompany()
        {
            return await _dbContext.Companies
                .Select(u => new CompanyDTO
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .ToListAsync();
        }

        [Tags("Company")]
        [HttpGet("company/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(long id)
        {
            var company = await _dbContext.Companies
                .Where(u => u.Id == id)
                .Select(u => new CompanyDTO
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .FirstOrDefaultAsync();

            if (company == null) return NotFound();

            return company;
        }

        #endregion
    }
}
