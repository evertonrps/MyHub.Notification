using MyHub.Notification.Domain.Entities;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Interfaces.Strategy;

namespace MyHub.Notification.ExternalService.Services
{
    public class WebNotificationStrategy : IWebNotificationStrategy
    {
        private readonly IEnumerable<IWebNotificationHandler> _providers;

        public WebNotificationStrategy(IEnumerable<IWebNotificationHandler> providers)
        {
            _providers = providers;
        }

        public Task<bool> SendWebNotification(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendWebNotification(message) ?? throw new ArgumentNullException(nameof(message));
        }
    }
}