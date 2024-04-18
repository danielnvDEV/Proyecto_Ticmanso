using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using TicmansoV2.Shared;

namespace TicmansoV2.Services
{
    public class ChatClient : IAsyncDisposable
    {
        private readonly HubConnection _hubConnection;

        public ChatClient(NavigationManager navigationManager)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/chathub"))
                .Build();
        }

        public async Task ConnectAsync()
        {
            await _hubConnection.StartAsync();
        }

        public async Task DisconnectAsync()
        {
            await _hubConnection.StopAsync();
        }

        public async Task SendMessageAsync(ChatMessageDTO message)
        {
            await _hubConnection.SendAsync("SendMessage", message);
        }

        public void ReceiveMessage(Action<ChatMessageDTO> handleMessage)
        {
            _hubConnection.On<ChatMessageDTO>("ReceiveMessage", handleMessage);
        }

        public async ValueTask DisposeAsync()
        {
            await _hubConnection.DisposeAsync();
        }
    }
}
