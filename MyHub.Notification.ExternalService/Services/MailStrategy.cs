using MyHub.Notification.Domain.Entities;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Interfaces.Strategy;

namespace MyHub.Notification.ExternalService.Services
{
    public class MailStrategy : IMailStrategy
    {
        private readonly IEnumerable<IMailHandler> _providers;

        public MailStrategy(IEnumerable<IMailHandler> providers)
        {
            _providers = providers;
        }

        public Task<bool> SendMail(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendMail(message) ?? throw new ArgumentNullException(nameof(message));
        }
    }
}