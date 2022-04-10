using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.ExternalService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.ExternalService.Providers.HubSpotProvider
{
    public class HubSpotExternalService : IMailHandlerService
    {
        private readonly ILogger<HubSpotExternalService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.HubSpot;

        public HubSpotExternalService(ILogger<HubSpotExternalService> logger)
        {
            _logger = logger;
        }

        public Task<bool> SendMail(Message message)
        {
            _logger.LogInformation("Sended by HubSpost");
            return Task.FromResult(true);
        }

        public Task<bool> SendSMS(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendWebNotification(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendWhatsAppMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
