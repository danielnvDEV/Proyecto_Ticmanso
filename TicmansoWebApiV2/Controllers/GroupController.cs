using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicmansoV2.Shared;
using TicmansoWebApiV2.Context;

namespace TicmansoWebApiV2.Controllers
{
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
        public async Task<ActionResult<GroupDTO>> CreateGroup(GroupDTO groupDTO)
        {
            var group = new Group
            {
                Name = groupDTO.Name,
                UserGroups = groupDTO.UserGroups.Select(ug => new UserGroup { UserId = ug.UserId }).ToList()
            };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            var createdGroupDTO = new GroupDTO
            {
                Id = group.Id,
                Name = group.Name,
                UserGroups = group.UserGroups.Select(ug => new UserGroupDTO { UserId = ug.UserId }).ToList()
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

    }
}
