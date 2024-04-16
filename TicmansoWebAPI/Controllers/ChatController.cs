
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TicmansoWebAPI.Models;

namespace TicmansoWebAPI.Models
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChatController : ControllerBase
    {
        
        private readonly TicmansoProContext _context;
        public ChatController(TicmansoProContext context)
        {
            
            _context = context;
        }
        [HttpGet("{contactId}")]
    public async Task<IActionResult> GetConversationAsync(long contactId)
    {
        long userId = long.Parse(User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).FirstOrDefault());
        var messages = await _context.ChatMessages
                .Where(h => (h.FromUserId == contactId && h.ToUserId == userId) || (h.FromUserId == userId && h.ToUserId == contactId))
                .OrderBy(a => a.CreatedDate)
                .Include(a => a.FromUser)
                .Include(a => a.ToUser)
                .Select(x => new ChatMessage
                {
                    FromUserId = x.FromUserId,
                    Message = x.Message,
                    CreatedDate = x.CreatedDate,
                    Id = x.Id,
                    ToUserId = x.ToUserId,
                    ToUser = x.ToUser,
                    FromUser = x.FromUser
                }).ToListAsync();
        return Ok(messages);
    }
    [HttpGet("users")]
    public async Task<IActionResult> GetUsersAsync()
    {
        long userId = long.Parse(User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).FirstOrDefault());
        var allUsers = await _context.Users.Where(user => user.Id != userId).ToListAsync();
        return Ok(allUsers);
    }
    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetUserDetailsAsync(long userId)
    {
        var user = await _context.Users.Where(user => user.Id == userId).FirstOrDefaultAsync();
        return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> SaveMessageAsync(ChatMessage message)
    {
        long userId = long.Parse(User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).FirstOrDefault());
        message.FromUserId = userId;
        message.CreatedDate = DateTime.Now;
        message.ToUser = await _context.Users.Where(user => user.Id == message.ToUserId).FirstOrDefaultAsync();
        await _context.ChatMessages.AddAsync(message);
        return Ok(await _context.SaveChangesAsync());
    }
    }
}
