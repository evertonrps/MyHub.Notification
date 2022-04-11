using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.ExternalService.Interfaces.Handler;

namespace MyHub.Notification.ExternalService.Providers.HubSpotProvider
{
    public class HubSpotSmsService : ISmsHandler
    {
        private readonly ILogger<HubSpotSmsService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.HubSpot;

        public HubSpotSmsService(ILogger<HubSpotSmsService> logger)
        {
            _logger = logger;
        }

        public Task<bool> SendSMS(Message message)
        {
            _logger.LogInformation("Sended SMS by HubSpot");
            return Task.FromResult(true);
        }
    }
}