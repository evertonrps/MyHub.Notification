using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.Exceptions;
using MyHub.Notification.Domain.SeedWork;
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

        public Task<ResponseEntity> SendPushNotification(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendPushNotification(message) 
                ?? Task.FromResult(new ResponseEntity
                {
                    Message = $"{message?.NotificationProvider?.GetDescription()} not support push notification service",
                    Success = false,
                    Type = ENotiticationType.PushNotification,
                    Provider = message?.NotificationProvider,
                });
            //?? throw new ServiceUnavailableException(message.NotificationProvider,$"{message?.NotificationProvider?.GetDescription()} not support push notification service");
        }
    }
}