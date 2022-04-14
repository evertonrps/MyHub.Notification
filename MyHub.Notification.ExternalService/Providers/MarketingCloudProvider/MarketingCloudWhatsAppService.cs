using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;

namespace MyHub.Notification.ExternalService.Providers.MarketingCloudProvider
{
    public class MarketingCloudWhatsAppService : IWhatsAppHandler
    {
        private readonly ILogger<MarketingCloudWhatsAppService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.MarketingCloud;

        public MarketingCloudWhatsAppService(ILogger<MarketingCloudWhatsAppService> logger)
        {
            _logger = logger;
        }

        public Task<ResponseEntity> SendWhatsAppMessage(Message message)
        {
            _logger.LogInformation("Sended WhatsApp Message by Marketing Cloud");
            return Task.FromResult(new ResponseEntity { Type = ENotiticationType.WhatsAppMessage, Provider = NotificationProvider, Success = true, Message = "Sended WhatsApp Message by Marketing Cloud" });
        }
    }
}