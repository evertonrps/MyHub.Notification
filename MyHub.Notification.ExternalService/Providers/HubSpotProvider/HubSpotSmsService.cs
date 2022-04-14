using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;
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

        public Task<ResponseEntity> SendSMS(Message message)
        {
            _logger.LogInformation("Sended SMS by HubSpot");
            return Task.FromResult(new ResponseEntity { Type = ENotiticationType.MobileNotification, Provider = NotificationProvider, Success = true, Message = "Sended SMS by HubSpot" });
        }
    }
}