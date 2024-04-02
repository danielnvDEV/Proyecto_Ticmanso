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

        #region Company
        [Tags("Company")]
        [HttpGet("company")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            return await _dbContext.Companies
                .Select(c => new CompanyDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Country = c.Country,
                    Address = c.Address,
                    PostalCode = c.PostalCode,
                    City = c.City,
                    Cif = c.Cif
                })
                .ToListAsync();
        }

        [Tags("Company")]
        [HttpGet("company/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(long id)
        {
            var company = await _dbContext.Companies
                .Where(c => c.Id == id)
                .Select(c => new CompanyDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Country = c.Country,
                    Address = c.Address,
                    PostalCode = c.PostalCode,
                    City = c.City,
                    Cif = c.Cif
                })
                .FirstOrDefaultAsync();

            if (company == null) return NotFound();

            return company;
        }

        [Tags("Company")]
        [HttpPost("company")]
        [Produces("application/json")]
        public async Task<ActionResult<CompanyDTO>> CreateCompany(CompanyDTO companyDTO)
        {
            var company = new Company
            {
                Name = companyDTO.Name,
                Country = companyDTO.Country,
                Address = companyDTO.Address,
                PostalCode = companyDTO.PostalCode,
                City = companyDTO.City,
                Cif = companyDTO.Cif
            };

            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        [Tags("Company")]
        [HttpPut("company/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCompany(long id, CompanyDTO companyDTO)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null) return NotFound();

            company.Name = companyDTO.Name;
            company.Country = companyDTO.Country;
            company.Address = companyDTO.Address;
            company.PostalCode = companyDTO.PostalCode;
            company.City = companyDTO.City;
            company.Cif = companyDTO.Cif;

            _dbContext.Companies.Update(company);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [Tags("Company")]
        [HttpDelete("company/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteCompany(long id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null) return NotFound();

            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Role
        [Tags("Role")]
        [HttpGet("role")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            return await _dbContext.Roles
                .Select(r => new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToListAsync();
        }

        [Tags("Role")]
        [HttpGet("role/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<RoleDTO>> GetRole(long id)
        {
            var role = await _dbContext.Roles
                .Where(r => r.Id == id)
                .Select(r => new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .FirstOrDefaultAsync();

            if (role == null) return NotFound();

            return role;
        }

        [Tags("Role")]
        [HttpPost("role")]
        [Produces("application/json")]
        public async Task<ActionResult<RoleDTO>> CreateRole(RoleDTO roleDTO)
        {
            var role = new Role
            {
                Name = roleDTO.Name
            };

            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        [Tags("Role")]
        [HttpPut("role/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateRole(long id, RoleDTO roleDTO)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null) return NotFound();

            role.Name = roleDTO.Name;

            _dbContext.Roles.Update(role);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [Tags("Role")]
        [HttpDelete("role/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteRole(long id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null) return NotFound();

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Priority
        [Tags("Priority")]
        [HttpGet("priority")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<PriorityDTO>>> GetPriorities()
        {
            return await _dbContext.Priorities
                .Select(p => new PriorityDTO
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
        }

        [Tags("Priority")]
        [HttpGet("priority/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<PriorityDTO>> GetPriority(long id)
        {
            var priority = await _dbContext.Priorities
                .Where(p => p.Id == id)
                .Select(p => new PriorityDTO
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .FirstOrDefaultAsync();

            if (priority == null) return NotFound();

            return priority;
        }

        [Tags("Priority")]
        [HttpPost("priority")]
        [Produces("application/json")]
        public async Task<ActionResult<PriorityDTO>> CreatePriority(PriorityDTO priorityDTO)
        {
            var priority = new Priority
            {
                Name = priorityDTO.Name
            };

            _dbContext.Priorities.Add(priority);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetPriority", new { id = priority.Id }, priority);
        }

        [Tags("Priority")]
        [HttpPut("priority/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePriority(long id, PriorityDTO priorityDTO)
        {
            var priority = await _dbContext.Priorities.FindAsync(id);
            if (priority == null) return NotFound();

            priority.Name = priorityDTO.Name;

            _dbContext.Priorities.Update(priority);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [Tags("Priority")]
        [HttpDelete("priority/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletePriority(long id)
        {
            var priority = await _dbContext.Priorities.FindAsync(id);
            if (priority == null) return NotFound();

            _dbContext.Priorities.Remove(priority);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Ticket
        [Tags("Ticket")]
        [HttpGet("ticket")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<TicketDTO>>> GetTickets()
        {
            return await _dbContext.Tickets
                .Select(t => new TicketDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreationDate = t.CreationDate,
                    ChangedDate = t.ChangedDate,
                    CloseDate = t.CloseDate,
                    ChatId = t.ChatId,
                    CreationUserId = t.CreationUserId,
                    SopportUserId = t.SopportUserId ?? 0,
                    PriorityId = t.PriorityId,
                    StatusId = t.StatusId
                })
                .ToListAsync();
        }

        [Tags("Ticket")]
        [HttpGet("ticket/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<TicketDTO>> GetTicket(long id)
        {
            var ticket = await _dbContext.Tickets
                .Where(t => t.Id == id)
                .Select(t => new TicketDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreationDate = t.CreationDate,
                    ChangedDate = t.ChangedDate,
                    CloseDate = t.CloseDate,
                    ChatId = t.ChatId,
                    CreationUserId = t.CreationUserId,
                    SopportUserId = t.SopportUserId ?? 0,
                    PriorityId = t.PriorityId,
                    StatusId = t.StatusId
                })
                .FirstOrDefaultAsync();

            if (ticket == null) return NotFound();

            return ticket;
        }

        [Tags("Ticket")]
        [HttpPost("ticket")]
        [Produces("application/json")]
        public async Task<ActionResult<TicketDTO>> CreateTicket(TicketDTO ticketDTO)
        {
            var ticket = new Ticket
            {
                Title = ticketDTO.Title,
                Description = ticketDTO.Description,
                CreationDate = ticketDTO.CreationDate,
                ChangedDate = ticketDTO.ChangedDate,
                CloseDate = ticketDTO.CloseDate,
                ChatId = ticketDTO.ChatId,
                CreationUserId = ticketDTO.CreationUserId,
                SopportUserId = ticketDTO.SopportUserId ?? 0,
                PriorityId = ticketDTO.PriorityId,
                StatusId = ticketDTO.StatusId
            };

            _dbContext.Tickets.Add(ticket);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }

        [Tags("Ticket")]
        [HttpPut("ticket/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateTicket(long id, TicketDTO ticketDTO)
        {
            var ticket = await _dbContext.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            ticket.Title = ticketDTO.Title;
            ticket.Description = ticketDTO.Description;
            ticket.ChangedDate = ticketDTO.ChangedDate;
            ticket.CloseDate = ticketDTO.CloseDate;
            ticket.ChatId = ticketDTO.ChatId;
            ticket.CreationUserId = ticketDTO.CreationUserId;
            ticket.SopportUserId = ticketDTO.SopportUserId ?? 0;
            ticket.PriorityId = ticketDTO.PriorityId;
            ticket.StatusId = ticketDTO.StatusId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [Tags("Ticket")]
        [HttpDelete("ticket/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteTicket(long id)
        {
            var ticket = await _dbContext.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            _dbContext.Tickets.Remove(ticket);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Status
        [Tags("Status")]
        [HttpGet("status")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> GetStatuses()
        {
            return await _dbContext.Statuses
                .Select(s => new StatusDTO
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }

        [Tags("Status")]
        [HttpGet("status/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<StatusDTO>> GetStatus(int id)
        {
            var status = await _dbContext.Statuses
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

        [Tags("Status")]
        [HttpPost("status")]
        [Produces("application/json")]
        public async Task<ActionResult<StatusDTO>> CreateStatus(StatusDTO statusDTO)
        {
            var status = new Status
            {
                Name = statusDTO.Name
            };

            _dbContext.Statuses.Add(status);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetStatus", new { id = status.Id }, new StatusDTO
            {
                Id = status.Id,
                Name = status.Name
            });
        }

        [Tags("Status")]
        [HttpPut("status/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateStatus(int id, StatusDTO statusDTO)
        {
            var status = await _dbContext.Statuses.FindAsync(id);
            if (status == null) return NotFound();

            status.Name = statusDTO.Name;

            _dbContext.Statuses.Update(status);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [Tags("Status")]
        [HttpDelete("status/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _dbContext.Statuses.FindAsync(id);
            if (status == null) return NotFound();

            _dbContext.Statuses.Remove(status);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Signing
        [Tags("Signing")]
        [HttpGet("signing")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<SigningDTO>>> GetSignings()
        {
            return await _dbContext.Signings
                .Select(s => new SigningDTO
                {
                    Date = s.Date,
                    EntryTime = s.EntryTime,
                    DepartureTime = s.DepartureTime,
                    UserId = s.UserId
                })
                .ToListAsync();
        }

        [Tags("Signing")]
        [HttpGet("signing/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<SigningDTO>> GetSigning(long id)
        {
            var signing = await _dbContext.Signings
                .Where(s => s.UserId == id)
                .Select(s => new SigningDTO
                {
                    Date = s.Date,
                    EntryTime = s.EntryTime,
                    DepartureTime = s.DepartureTime,
                    UserId = s.UserId
                })
                .FirstOrDefaultAsync();

            if (signing == null) return NotFound();

            return signing;
        }

        [Tags("Signing")]
        [HttpPost("signing")]
        [Produces("application/json")]
        public async Task<ActionResult<SigningDTO>> CreateSigning(SigningDTO signingDTO)
        {
            var signing = new Signing
            {
                Date = signingDTO.Date,
                EntryTime = signingDTO.EntryTime,
                DepartureTime = signingDTO.DepartureTime,
                UserId = signingDTO.UserId
            };

            _dbContext.Signings.Add(signing);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetSigning", new { id = signing.UserId }, new SigningDTO
            {
                Date = signing.Date,
                EntryTime = signing.EntryTime,
                DepartureTime = signing.DepartureTime,
                UserId = signing.UserId
            });
        }

        [Tags("Signing")]
        [HttpPut("signing/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateSigning(long id, SigningDTO signingDTO)
        {
            var signing = await _dbContext.Signings.FindAsync(id);
            if (signing == null) return NotFound();

            signing.Date = signingDTO.Date;
            signing.EntryTime = signingDTO.EntryTime;
            signing.DepartureTime = signingDTO.DepartureTime;
            signing.UserId = signingDTO.UserId;

            _dbContext.Signings.Update(signing);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [Tags("Signing")]
        [HttpDelete("signing/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteSigning(long id)
        {
            var signing = await _dbContext.Signings.FindAsync(id);
            if (signing == null) return NotFound();

            _dbContext.Signings.Remove(signing);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region GeneralViewTicket
        [Tags("GeneralViewTicket")]
        [HttpGet("generalviewticket")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<GeneralViewTicketDTO>>> GetGeneralViewTickets()
        {
            return await _dbContext.Tickets
                .Select(t => new GeneralViewTicketDTO
                {
                    NumTicket = t.Id,
                    Tittle = t.Title,
                    Description = t.Description,
                    CreationUser = t.CreationUser.Name + " " + t.CreationUser.Surnames,
                    Status = t.Status.Name,
                    Priority = t.Priority.Name,
                    
                })
                .ToListAsync();
        }

        [Tags("GeneralViewTicket")]
        [HttpGet("generalviewticket/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult<GeneralViewTicketDTO>> GetGeneralViewTicket(long id)
        {
            var ticket = await _dbContext.Tickets
                .Where(t => t.Id == id)
                .Select(t => new GeneralViewTicketDTO
                {
                    NumTicket = t.Id,
                    Tittle = t.Title,
                    Description = t.Description,
                    CreationUser = t.CreationUser.Name + " " + t.CreationUser.Surnames,
                    Status = t.Status.Name,
                    Priority = t.Priority.Name,
                   
                })
                .FirstOrDefaultAsync();

            if (ticket == null) return NotFound();

            return ticket;
        }
        #endregion
    }
}
