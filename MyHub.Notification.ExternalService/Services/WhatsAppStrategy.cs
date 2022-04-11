using MyHub.Notification.Domain.Entities;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Interfaces.Strategy;

namespace MyHub.Notification.ExternalService.Services
{
    public class WhatsAppStrategy : IWhatsAppStrategy
    {
        private readonly IEnumerable<IWhatsAppHandler> _providers;

        public WhatsAppStrategy(IEnumerable<IWhatsAppHandler> providers)
        {
            _providers = providers;
        }

        public Task<bool> SendWhatsAppMessage(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendWhatsAppMessage(message) ?? throw new ArgumentNullException(nameof(message));
        }
    }
}