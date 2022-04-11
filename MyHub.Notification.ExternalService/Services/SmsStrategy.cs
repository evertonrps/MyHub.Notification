using MyHub.Notification.Domain.Entities;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Interfaces.Strategy;

namespace MyHub.Notification.ExternalService.Services
{
    public class SmsStrategy : ISmsStrategy
    {
        private readonly IEnumerable<ISmsHandler> _providers;

        public SmsStrategy(IEnumerable<ISmsHandler> providers)
        {
            _providers = providers;
        }

        public Task<bool> SendSMS(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendSMS(message) ?? throw new ArgumentNullException(nameof(message));
        }
    }
}