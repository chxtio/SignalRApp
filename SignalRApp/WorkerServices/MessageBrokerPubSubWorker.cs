using Microsoft.AspNetCore.SignalR;

namespace SignalRApp.WorkerServices
{
    public sealed class MessageBrokerPubSubWorker : BackgroundService
    {
        private IHubContext<MessageBrokerHub> _messageBrokerHubContext;

        public MessageBrokerPubSubWorker(IHubContext<MessageBrokerHub> messageBrokerHubContext)
        {
            _messageBrokerHubContext = messageBrokerHubContext;
        }

        // worker service starts and calls execute async method to loop and publish messages every sec
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //throw new NotImplementedException();
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
                var eventMessage = new EventMessage($"ID_{ Guid.NewGuid():N}", $"Title_{ Guid.NewGuid():N}", DateTime.UtcNow);
                // Get access to clients connected to hub and send to all

                await _messageBrokerHubContext.Clients.All.SendAsync("onMessagedReceived", eventMessage, stoppingToken);
            }
        }
    }
}
