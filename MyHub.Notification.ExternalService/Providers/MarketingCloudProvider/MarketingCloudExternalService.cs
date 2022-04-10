using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.ExternalService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.ExternalService.Providers.MarketingCloudProvider
{
    public class MarketingCloudExternalService : IMailHandlerService
    {
        private readonly ILogger<MarketingCloudExternalService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.MarketingCloud;

        public MarketingCloudExternalService(ILogger<MarketingCloudExternalService> logger)
        {
            _logger = logger;
        }

        public Task<bool> SendMail(Message message)
        {
            _logger.LogInformation("Sended by Marketing Clould");
            return Task.FromResult(true);
        }

        public Task<bool> SendPush(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendSMS(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
