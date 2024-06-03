using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicmansoV2.Shared;
using TicmansoWebApiV2.Context;

namespace TicmansoWebApiV2.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly TicmansoDbContext _context;

        public GroupController(TicmansoDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<GroupDTO>> PostGroup(GroupDTO groupDTO)
        {
            var group = new Group
            {
                Name = groupDTO.Name,
                Description = groupDTO.Description,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            foreach (var userGroupDTO in groupDTO.UserGroups)
            {
                var userGroup = new UserGroup
                {
                    UserId = userGroupDTO.UserId,
                    GroupId = group.Id
                };
                _context.UserGroups.Add(userGroup);
            }

            await _context.SaveChangesAsync();

            var createdGroupDTO = new GroupDTO
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CreatedAt = DateTime.UtcNow,
                UserGroups = group.UserGroups.Select(ug => new UserGroupDTO
                {
                    UserId = ug.UserId,
                    GroupId = ug.GroupId
                }).ToList()
            };

            return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, createdGroupDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroup(int id)
        {
            var group = await _context.Groups
                .Include(g => g.UserGroups)
                .ThenInclude(ug => ug.User)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            var groupDTO = new GroupDTO
            {
                Id = group.Id,
                Name = group.Name,
                UserGroups = group.UserGroups.Select(ug => new UserGroupDTO
                {
                    UserId = ug.UserId,
                }).ToList()
            };

            return groupDTO;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroupsByUser(string userId)
        {
            var groups = await _context.Groups
                .Where(g => g.UserGroups.Any(ug => ug.UserId == userId))
                .Select(g => new GroupDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    UserGroups = g.UserGroups.Select(ug => new UserGroupDTO
                    {
                        UserId = ug.UserId,                      
                    }).ToList()
                })
                .ToListAsync();

            return groups;
        }


    }
}
