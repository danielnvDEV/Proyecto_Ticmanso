namespace TicmansoWebApiV2.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using TicmansoWebApiV2.Context;

    public class ChatHub : Hub
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
