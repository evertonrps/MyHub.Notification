using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;

namespace MyHub.Notification.ExternalService.Providers.MarketingCloudProvider
{
    public class MarketingCloudMailService : IMailHandler
    {
        private readonly ILogger<MarketingCloudMailService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.MarketingCloud;

        public MarketingCloudMailService(ILogger<MarketingCloudMailService> logger)
        {
            _logger = logger;
        }

        public Task<ResponseEntity> SendMail(Message message)
        {
            _logger.LogInformation("Sended Mail by Marketing Clould");            
            return Task.FromResult(new ResponseEntity { Type = ENotiticationType.Email, Provider = NotificationProvider, Success = true, Message = "Sended Mail by Marketing Clould" });
        }
    }
}