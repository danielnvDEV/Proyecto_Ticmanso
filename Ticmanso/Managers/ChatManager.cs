
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TicmansoCrud.Shared;
using TicmansoWebAPI.Models;
using TicmansoWebAPI;

namespace TicmansoWebAPI.Models
{
public class ChatManager : IChatManager
{
    private readonly HttpClient _httpClient;

    public ChatManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<ChatMessageDTO>> GetConversationAsync(long contactId)
    {
        return await _httpClient.GetFromJsonAsync<List<ChatMessageDTO>>($"api/chat/{contactId}");
    }
    public async Task<UserDTO> GetUserDetailsAsync(long userId)
    {
        return await _httpClient.GetFromJsonAsync<UserDTO>($"api/chat/users/{userId}");
    }
    public async Task<List<UserDTO>> GetUsersAsync()
    {
        var data = await _httpClient.GetFromJsonAsync<List<UserDTO>>("api/chat/users");
        return data;
    }
    public async Task SaveMessageAsync(ChatMessageDTO message)
    {
        await _httpClient.PostAsJsonAsync("api/chat", message);
    }
}
}
