
using System.Collections.Generic;
using System.Threading.Tasks;
using TicmansoCrud.Shared;

namespace TicmansoWebAPI.Models
{
public interface IChatManager
{
    Task<List<UserDTO>> GetUsersAsync();
    Task SaveMessageAsync(ChatMessageDTO message);
    Task<List<ChatMessageDTO>> GetConversationAsync(long contactId);
    Task<UserDTO> GetUserDetailsAsync(long userId);
}
}
