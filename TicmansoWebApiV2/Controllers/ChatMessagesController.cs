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
    public class ChatMessagesController : ControllerBase
    {
        private readonly TicmansoDbContext _context;

        public ChatMessagesController(TicmansoDbContext context)
        {
            _context = context;
        }

        // GET: api/ChatMessages/5
        [HttpGet("{ticketId}", Name = "GetChatMessagesByTicketId")]
        public async Task<ActionResult<IEnumerable<ChatMessageDTO>>> GetChatMessages(int ticketId)
        {
            var chatMessages = await _context.ChatMessages
                .Where(m => m.TicketId == ticketId)
                .Select(m => new ChatMessageDTO
                {
                    Id = m.Id,
                    Content = m.Content,
                    Timestamp = m.Timestamp,
                    SenderId = m.SenderId,
                    ReceiverId = m.ReceiverId
                })
                .ToListAsync();

            return chatMessages;
        }

        // POST: api/ChatMessages
        [HttpPost]
        public async Task<ActionResult<ChatMessageDTO>> PostChatMessage(ChatMessageDTO chatMessageDTO)
        {
            var chatMessage = new ChatMessage
            {
                TicketId = chatMessageDTO.TicketId,
                Content = chatMessageDTO.Content,
                Timestamp = chatMessageDTO.Timestamp,
                SenderId = chatMessageDTO.SenderId,
                ReceiverId = chatMessageDTO.ReceiverId
            };

            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatMessagesByTicketId", new { ticketId = chatMessage.TicketId }, chatMessageDTO);
        }
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ChatMessageDTO>>> GetChatMessagesByUser(string userId)
        {
            var chatMessages = await _context.ChatMessages
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .Select(m => new ChatMessageDTO
                {
                    Id = m.Id,
                    Content = m.Content,
                    Timestamp = m.Timestamp,
                    SenderId = m.SenderId,
                    ReceiverId = m.ReceiverId
                })
                .ToListAsync();

            return chatMessages;
        }
    }
}
