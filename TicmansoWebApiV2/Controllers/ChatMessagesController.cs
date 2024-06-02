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
        // 
        [HttpPost]
        public async Task<ActionResult<ChatMessageDTO>> PostChatMessage(ChatMessageDTO chatMessageDTO)
        {
            var chatMessage = new ChatMessage
            {
                TicketId = chatMessageDTO.TicketId,
                Content = chatMessageDTO.Content,
                Timestamp = chatMessageDTO.Timestamp,
                SenderId = chatMessageDTO.SenderId,
                ReceiverId = chatMessageDTO.ReceiverId,
                GroupId = chatMessageDTO.GroupId
            };

            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();
            if (chatMessage.TicketId != null) {
                return CreatedAtAction("GetChatMessagesByTicketId", new { ticketId = chatMessage.TicketId }, chatMessageDTO);
            }
            else
                return CreatedAtAction("GetChatMessages", new { id = chatMessage.Id }, new ChatMessageDTO
                {
                    Id = chatMessage.Id,
                    TicketId = chatMessage.TicketId,
                    Content = chatMessage.Content,
                    Timestamp = chatMessage.Timestamp,
                    SenderId = chatMessage.SenderId,
                    ReceiverId = chatMessage.ReceiverId,
                    GroupId=chatMessage.GroupId
                });
            
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ChatMessageDTO>>> GetChatMessagesByUser(string userId)
        {
            var chatMessages = await _context.ChatMessages
                .Where(m => m.SenderId == userId || m.ReceiverId == userId && m.TicketId==null)
                .Select(m => new ChatMessageDTO
                {
                    Id = m.Id,
                    Content = m.Content,
                    Timestamp = m.Timestamp,
                    SenderId = m.SenderId,
                    ReceiverId = m.ReceiverId,
                    GroupId = m.GroupId
                })
                .ToListAsync();

            return chatMessages;
        }
        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<ChatMessageDTO>>> GetChatMessagesByGroup(int groupId)
        {
            var chatMessages = await _context.ChatMessages
                .Where(m => m.GroupId == groupId)
                .Select(m => new ChatMessageDTO
                {
                    Id = m.Id,
                    Content = m.Content,
                    Timestamp = m.Timestamp,
                    SenderId = m.SenderId,
                    GroupId = m.GroupId
                })
                .ToListAsync();

            return chatMessages;
        }

    }
}
