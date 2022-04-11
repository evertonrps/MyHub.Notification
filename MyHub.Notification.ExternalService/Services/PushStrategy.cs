using MyHub.Notification.Domain.Entities;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Interfaces.Strategy;

namespace MyHub.Notification.ExternalService.Services
{
    public class PushStrategy : IPushStrategy
    {
        private readonly IEnumerable<IPushNotificationHandler> _providers;

        public PushStrategy(IEnumerable<IPushNotificationHandler> providers)
        {
            _providers = providers;
        }

        public Task<bool> SendPushNotification(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendPushNotification(message) ?? throw new ArgumentNullException(nameof(message));
        }
    }
}