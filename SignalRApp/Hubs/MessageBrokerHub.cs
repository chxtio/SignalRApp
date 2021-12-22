using Microsoft.AspNetCore.SignalR;

namespace SignalRApp
{
    public sealed class MessageBrokerHub : Hub
    {
        public Task ReceiveMessage(string message)
        {
            return Task.CompletedTask;
        }
    }
}
