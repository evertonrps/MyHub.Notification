﻿using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
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

        public Task<bool> SendMail(Message message)
        {
            _logger.LogInformation("Sended Mail by HubSpost");
            return Task.FromResult(true);
        }
    }
}