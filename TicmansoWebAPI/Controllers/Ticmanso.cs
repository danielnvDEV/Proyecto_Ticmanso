using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicmansoWebAPI.Models;
using TicmansoCrud.Shared; // Asumiendo que aquí se encuentran los DTOs
using Microsoft.EntityFrameworkCore;

namespace TicmansoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicmansoController : ControllerBase
    {
        private readonly TicmansoProContext _dbContext;

        public TicmansoController(TicmansoProContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Chat

        // GET: api/Ticmanso/Chats
        [HttpGet("Chats")]
        public async Task<ActionResult<IEnumerable<ChatDTO>>> GetChats()
        {
            var chats = await _dbContext.Chats.ToListAsync();
            var ChatDTOs = chats.Select(c => new ChatDTO
            {
                Id = c.Id,
                Messages = c.Messages,
                UserId = c.UserId
            }).ToList();

            return Ok(ChatDTOs);
        }

        // GET: api/Ticmanso/Chats/5
        [HttpGet("Chats/{id}")]
        public async Task<ActionResult<ChatDTO>> GetChat(int id)
        {
            var chat = await _dbContext.Chats.FindAsync(id);
            if (chat == null) return NotFound();

            var ChatDTO = new ChatDTO
            {
                Id = chat.Id,
                Messages = chat.Messages,
                UserId = chat.UserId
            };

            return Ok(ChatDTO);
        }

        // POST: api/Ticmanso/Chats
        [HttpPost("Chats")]
        public async Task<ActionResult<ChatDTO>> CreateChat(ChatDTO ChatDTO)
        {
            var chat = new Chat
            {
                Messages = ChatDTO.Messages,
                UserId = ChatDTO.UserId
            };

            _dbContext.Chats.Add(chat);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetChat", new { id = chat.Id }, chat);
        }

        // PUT: api/Ticmanso/Chats/5
        [HttpPut("Chats/{id}")]
        public async Task<IActionResult> UpdateChat(int id, ChatDTO ChatDTO)
        {
            var chat = await _dbContext.Chats.FindAsync(id);
            if (chat == null) return NotFound();

            chat.Messages = ChatDTO.Messages;
            chat.UserId = ChatDTO.UserId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Ticmanso/Chats/5
        [HttpDelete("Chats/{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            var chat = await _dbContext.Chats.FindAsync(id);
            if (chat == null) return NotFound();

            _dbContext.Chats.Remove(chat);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Company

        // GET: api/Ticmanso/Companies
        [HttpGet("Companies")]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            var companies = await _dbContext.Companies.ToListAsync();
            var CompanyDTOs = companies.Select(c => new CompanyDTO
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                // ... (Map other properties)
            }).ToList();

            return Ok(CompanyDTOs);
        }

        // GET: api/Ticmanso/Companies/5
        [HttpGet("Companies/{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null) return NotFound();

            var CompanyDTO = new CompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                // ... (Map other properties)
            };

            return Ok(CompanyDTO);
        }

        // POST: api/Ticmanso/Companies
        [HttpPost("Companies")]
        public async Task<ActionResult<CompanyDTO>> CreateCompany(CompanyDTO CompanyDTO)
        {
            var company = new Company
            {
                Name = CompanyDTO.Name,
                Address = CompanyDTO.Address,
                // ... (Map other properties)
            };

            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // PUT: api/Ticmanso/Companies/5
        [HttpPut("Companies/{id}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyDTO CompanyDTO)
        {
            // ... Logic to find the company, update properties, and save changes
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Ticmanso/Companies/5
        [HttpDelete("Companies/{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            // ... Logic to find the company and delete it
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Priority

        // GET: api/Ticmanso/Priorities
        [HttpGet("Priorities")]
        public async Task<ActionResult<IEnumerable<PriorityDTO>>> GetPriorities()
        {
            var priorities = await _dbContext.Priorities.ToListAsync();
            var PriorityDTOs = priorities.Select(p => new PriorityDTO
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return Ok(PriorityDTOs);
        }

        // GET: api/Ticmanso/Priorities/5
        [HttpGet("Priorities/{id}")]
        public async Task<ActionResult<PriorityDTO>> GetPriority(int id)
        {
            var priority = await _dbContext.Priorities.FindAsync(id);
            if (priority == null) return NotFound();

            var PriorityDTO = new PriorityDTO
            {
                Id = priority.Id,
                Name = priority.Name
            };

            return Ok(PriorityDTO);
        }


        // POST: api/Ticmanso/Priorities
        [HttpPost("Priorities")]
        public async Task<ActionResult<PriorityDTO>> CreatePriority(PriorityDTO PriorityDTO)
        {
            var priority = new Priority
            {
                Name = PriorityDTO.Name
            };

            _dbContext.Priorities.Add(priority);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetPriority", new { id = priority.Id }, priority);
        }

        // PUT: api/Ticmanso/Priorities/5
        [HttpPut("Priorities/{id}")]
        public async Task<IActionResult> UpdatePriority(int id, PriorityDTO PriorityDTO)
        {
            var priority = await _dbContext.Priorities.FindAsync(id);
            if (priority == null) return NotFound();

            priority.Name = PriorityDTO.Name;

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }


        // DELETE: api/Ticmanso/Priorities/5
        [HttpDelete("Priorities/{id}")]
        public async Task<IActionResult> DeletePriority(int id)
        {
            var priority = await _dbContext.Priorities.FindAsync(id);
            if (priority == null) return NotFound();

            _dbContext.Priorities.Remove(priority);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Role

        // GET: api/Ticmanso/Roles
        [HttpGet("Roles")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            var roles = await _dbContext.Roles.ToListAsync();
            var RoleDTOs = roles.Select(r => new RoleDTO
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            return Ok(RoleDTOs);
        }

        // GET: api/Ticmanso/Roles/5
        [HttpGet("Roles/{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null) return NotFound();

            var RoleDTO = new RoleDTO
            {
                Id = role.Id,
                Name = role.Name
            };

            return Ok(RoleDTO);
        }

        // POST: api/Ticmanso/Roles
        [HttpPost("Roles")]
        public async Task<ActionResult<RoleDTO>> CreateRole(RoleDTO RoleDTO)
        {
            var role = new Role
            {
                Name = RoleDTO.Name
            };

            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        // PUT: api/Ticmanso/Roles/5
        [HttpPut("Roles/{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleDTO RoleDTO)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null) return NotFound();

            role.Name = RoleDTO.Name;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Ticmanso/Roles/5
        [HttpDelete("Roles/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if (role == null) return NotFound();

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Status

        // GET: api/Ticmanso/Statuses
        [HttpGet("Statuses")]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> GetStatuses()
        {
            var statuses = await _dbContext.Statuses.ToListAsync();
            var StatusDTOs = statuses.Select(s => new StatusDTO
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return Ok(StatusDTOs);
        }

        // GET: api/Ticmanso/Statuses/5
        [HttpGet("Statuses/{id}")]
        public async Task<ActionResult<StatusDTO>> GetStatus(int id)
        {
            var status = await _dbContext.Statuses.FindAsync(id);
            if (status == null) return NotFound();

            var StatusDTO = new StatusDTO
            {
                Id = status.Id,
                Name = status.Name
            };

            return Ok(StatusDTO);
        }

        // POST: api/Ticmanso/Statuses
        [HttpPost("Statuses")]
        public async Task<ActionResult<StatusDTO>> CreateStatus(StatusDTO StatusDTO)
        {
            var status = new Status
            {
                Name = StatusDTO.Name
            };

            _dbContext.Statuses.Add(status);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetStatus", new { id = status.Id }, status);
        }

        // PUT: api/Ticmanso/Statuses/5
        [HttpPut("Statuses/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, StatusDTO StatusDTO)
        {
            var status = await _dbContext.Statuses.FindAsync(id);
            if (status == null) return NotFound();

            status.Name = StatusDTO.Name;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Ticmanso/Statuses/5
        [HttpDelete("Statuses/{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _dbContext.Statuses.FindAsync(id);
            if (status == null) return NotFound();

            _dbContext.Statuses.Remove(status);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Ticket

        // GET: api/Ticmanso/Tickets
        [HttpGet("Tickets")]
        public async Task<ActionResult<IEnumerable<TicketDTO>>> GetTickets()
        {
            var tickets = await _dbContext.Tickets
                .Include(t => t.Chat)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.CreationUser) 
                .Include(t => t.SopportUserId) 
                .ToListAsync();

            var TicketDTOs = tickets.Select(t => new TicketDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreationDate = t.CreationDate,
                ChangedDate = t.ChangedDate,
                CloseDate = t.CloseDate,
                ChatId = t.ChatId,
                SopportUserId = t.SopportUserId,
                PriorityId = t.PriorityId,
                StatusId = t.StatusId,
                CreationUserId = t.CreationUserId
            }).ToList();

            return Ok(TicketDTOs);
        }

        // GET: api/Ticmanso/Tickets/5
        [HttpGet("Tickets/{id}")]
        public async Task<ActionResult<TicketDTO>> GetTicket(int id)
        {
            var ticket = await _dbContext.Tickets
                .Include(t => t.Chat)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.CreationUser) // Assuming relationship to User
                .Include(t => t.SopportUserId) // Assuming relationship to User
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null) return NotFound();

            var TicketDTO = new TicketDTO
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                CreationDate = ticket.CreationDate,
                ChangedDate = ticket.ChangedDate,
                CloseDate = ticket.CloseDate,
                ChatId = ticket.ChatId,
                SopportUserId = ticket.SopportUserId,
                PriorityId = ticket.PriorityId,
                StatusId = ticket.StatusId,
                CreationUserId = ticket.CreationUserId
            };

            return Ok(TicketDTO);
        }

        // POST: api/Ticmanso/Tickets
        [HttpPost("Tickets")]
        public async Task<ActionResult<TicketDTO>> CreateTicket(TicketDTO TicketDTO)
        {
            var ticket = new Ticket
            {
                Title = TicketDTO.Title,
                Description = TicketDTO.Description,
                CreationDate = DateTime.Now,
                PriorityId = TicketDTO.PriorityId,
                StatusId = TicketDTO.StatusId,
                CreationUserId = TicketDTO.CreationUserId
            };

            _dbContext.Tickets.Add(ticket);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // PUT: api/Ticmanso/Tickets/5
        [HttpPut("Tickets/{id}")]
        public async Task<IActionResult> UpdateTicket(int id, TicketDTO TicketDTO)
        {
            var ticket = await _dbContext.Tickets.FindAsync(id);

            if (ticket == null) return NotFound();

            ticket.Title = TicketDTO.Title;
            ticket.Description = TicketDTO.Description;
            ticket.ChangedDate = DateTime.Now;
            ticket.PriorityId = TicketDTO.PriorityId;
            ticket.StatusId = TicketDTO.StatusId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Ticmanso/Tickets/5
        [HttpDelete("Tickets/{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _dbContext.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            // Lógica adicional para manejar dependencias:
            if (await _dbContext.Chats.AnyAsync(c => c.Id == id))
            {
                // Manejar caso de chats relacionados (ej: retornar BadRequest, eliminar dependencias, etc.)
                return BadRequest("El ticket no se puede eliminar porque tiene chats asociados");
            }

            _dbContext.Tickets.Remove(ticket);
            await _dbContext.SaveChangesAsync();
            return NoContent();
            

        }
        #endregion

        #region User
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return await _dbContext.Users
                .Include(u => u.Role) // Include related data
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surnames = u.Surnames,
                    Mail = u.Mail,
                    // Add other properties as needed, consider security
                    RoleId = u.Role.Id
                })
                .ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _dbContext.Users
                .Include(u => u.Role)
                .Where(u => u.Id == id)
                .Select(u => new UserDTO
                {
                    // ...map properties
                })
                .FirstOrDefaultAsync();

            if (user == null) return NotFound();

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO UserDTO)
        {
            // Consider input validation and password hashing

            var user = new User
            {
                Name = UserDTO.Name,
                Surnames = UserDTO.Surnames,
                Mail = UserDTO.Mail,
                Password = UserDTO.Password, // Hash password in a production environment
                RoleId = UserDTO.RoleId,
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO UserDTO)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return NotFound();

            // Consider input validation and password hashing

            user.Name = UserDTO.Name;
            user.Surnames = UserDTO.Surnames;
            user.Mail = UserDTO.Mail;
            user.Password = UserDTO.Password; // Hash password in a production environment
            user.RoleId = UserDTO.RoleId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return NotFound();

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region SignIn
        // GET: api/Signings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SigningDTO>>> GetSignings()
        {
            return await _dbContext.Signings
                .Include(s => s.User) // Include related data
                .Select(s => new SigningDTO
                {
                    Date = s.Date,
                    DepartureTime = s.DepartureTime,
                    EntryTime = s.EntryTime,
                    UserId = s.UserId,
                })
                .ToListAsync();
        }

        // GET: api/Signings/2023-03-20
        [HttpGet("{date}")]
        public async Task<ActionResult<SigningDTO>> GetSigning(DateTime date)
        {
            var signing = await _dbContext.Signings
                  .Include(s => s.User)
                  .Where(s => s.Date == date.Date) // Modified line
                  .Select(s => new SigningDTO
                  {
                      // ...map properties
                  })
                  .FirstOrDefaultAsync();

            if (signing == null) return NotFound();

            return signing;
        }

        // POST: api/Signings
        [HttpPost]
        public async Task<ActionResult<SigningDTO>> CreateSigning(SigningDTO SigningDTO)
        {
            // Consider input validation and business rules

            var signing = new Signing
            {
                Date = SigningDTO.Date,
                DepartureTime = SigningDTO.DepartureTime,
                EntryTime = SigningDTO.EntryTime,
                UserId = SigningDTO.UserId
            };

            _dbContext.Signings.Add(signing);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetSigning", new { date = signing.Date }, signing);
        }

        // PUT: api/Signings/2023-03-20
        [HttpPut("{date}")]
        public async Task<IActionResult> UpdateSigning(DateTime date, SigningDTO SigningDTO)
        {
            var signing = await _dbContext.Signings.FindAsync(date);
            if (signing == null) return NotFound();

            // Consider input validation and business rules

            signing.DepartureTime = SigningDTO.DepartureTime;
            signing.EntryTime = SigningDTO.EntryTime;
            signing.UserId = SigningDTO.UserId;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Signings/2023-03-20
        [HttpDelete("{date}")]
        public async Task<IActionResult> DeleteSigning(DateTime date)
        {
            var signing = await _dbContext.Signings.FindAsync(date);
            if (signing == null) return NotFound();

            _dbContext.Signings.Remove(signing);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        [HttpGet("GeneralViewTickets")]
        public async Task<ActionResult<IEnumerable<GeneralViewTicketDTO>>> GetGeneralViewTickets()
        {
            return await _dbContext.GeneralViewTickets
                .Select(t => new GeneralViewTicketDTO { /* Mapear propiedades de la vista a GeneralViewTicketDTO */ })
                .ToListAsync();
        }
    }
}
