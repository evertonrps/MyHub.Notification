using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;

namespace MyHub.Notification.ExternalService.Providers.HubSpotProvider
{
    public class HubSpotWhatsAppService : IWhatsAppHandler
    {
        private readonly ILogger<HubSpotWhatsAppService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.HubSpot;

        public HubSpotWhatsAppService(ILogger<HubSpotWhatsAppService> logger)
        {
            _logger = logger;
        }

        public Task<ResponseEntity> SendWhatsAppMessage(Message message)
        {
            _logger.LogInformation("Sended WhatsApp Message by HubSpot");
            return Task.FromResult(new ResponseEntity { Type = ENotiticationType.WhatsAppMessage, Provider = NotificationProvider, Success = true, Message = "Sended WhatsApp Message by HubSpot" });            
        }
    }
}