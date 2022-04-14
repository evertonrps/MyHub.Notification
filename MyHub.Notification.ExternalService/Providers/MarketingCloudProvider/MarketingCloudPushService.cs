using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;

namespace MyHub.Notification.ExternalService.Providers.MarketingCloudProvider
{
    public class MarketingCloudPushService : IPushNotificationHandler
    {
        private readonly ILogger<MarketingCloudPushService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.MarketingCloud;

        public MarketingCloudPushService(ILogger<MarketingCloudPushService> logger)
        {
            _logger = logger;
        }

        public Task<ResponseEntity> SendPushNotification(Message message)
        {
            _logger.LogInformation("Sended Push by Marketing Cloud");
            return Task.FromResult(new ResponseEntity { Type = ENotiticationType.PushNotification, Provider = NotificationProvider, Success = true, Message = "Sended Push by Marketing Cloud" });
        }
    }
}