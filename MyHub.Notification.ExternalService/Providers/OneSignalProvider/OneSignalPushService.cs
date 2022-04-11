using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.ExternalService.Interfaces.Handler;

namespace MyHub.Notification.ExternalService.Providers.OneSignalProvider
{
    public class OneSignalPushService : IPushNotificationHandler
    {
        private readonly ILogger<OneSignalPushService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.OneSignal;

        public OneSignalPushService(ILogger<OneSignalPushService> logger)
        {
            _logger = logger;
        }

        public Task<bool> SendPushNotification(Message message)
        {
            _logger.LogInformation("Sended Push by One Signal");
            return Task.FromResult(true);
        }
    }
}