using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;

namespace MyHub.Notification.ExternalService.Providers.HubSpotProvider
{
    public class HubSpotWebNotificationService : IWebNotificationHandler
    {
        private readonly ILogger<HubSpotWebNotificationService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.HubSpot;

        public HubSpotWebNotificationService(ILogger<HubSpotWebNotificationService> logger)
        {
            _logger = logger;
        }

        public Task<ResponseEntity> SendWebNotification(Message message)
        {
            _logger.LogInformation("Sended Web Notification by HubSpot");
            return Task.FromResult(new ResponseEntity { Type = ENotiticationType.WebNotification, Provider = NotificationProvider, Success = true, Message = "Sended Web Notification by HubSpot" });            
        }
    }
}