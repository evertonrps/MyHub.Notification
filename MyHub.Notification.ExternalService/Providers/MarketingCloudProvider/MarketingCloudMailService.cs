using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
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

        public Task<bool> SendMail(Message message)
        {
            _logger.LogInformation("Sended Mail by Marketing Clould");
            return Task.FromResult(true);
        }
    }
}