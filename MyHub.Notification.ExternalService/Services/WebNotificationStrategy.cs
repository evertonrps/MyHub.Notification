using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;
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

        public Task<ResponseEntity> SendWebNotification(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendWebNotification(message)
                 ?? Task.FromResult(new ResponseEntity
                 {
                     Message = $"{message?.NotificationProvider?.GetDescription()} not support web notification service",
                     Success = false,
                     Type = ENotiticationType.WebNotification,
                     Provider = message?.NotificationProvider
                 });
            //?? throw new ServiceUnavailableException(message.NotificationProvider,$"{message?.NotificationProvider?.GetDescription()} not support web notification service");
        }
    }
}