using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.Exceptions;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;

namespace MyHub.Notification.ExternalService.Providers.HubSpotProvider
{
    public class HubSpotMailService : IMailHandler
    {
        private readonly ILogger<HubSpotMailService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.HubSpot;

        public HubSpotMailService(ILogger<HubSpotMailService> logger)
        {
            _logger = logger;
        }

        public Task<ResponseEntity> SendMail(Message message)
        {
            if (message.Template == null)
                throw new TemplateRequiredException("Template required for HubSpot",new List<ResponseEntity>());

            _logger.LogInformation("Sended Mail by HubSpost");
            return Task.FromResult(new ResponseEntity { Type = ENotiticationType.Email, Provider = NotificationProvider, Success = true, Message = "Sended Mail by HubSpost" });
        }
    }
}