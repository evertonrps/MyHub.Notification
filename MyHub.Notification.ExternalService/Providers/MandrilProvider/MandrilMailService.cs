﻿using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.ExternalService.Interfaces.Handler;

namespace MyHub.Notification.ExternalService.Providers.MandrilProvider
{
    public class MandrilMailService : IMailHandler
    {
        private readonly ILogger<MandrilMailService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.Mandril;

        public MandrilMailService(ILogger<MandrilMailService> logger)
        {
            _logger = logger;
        }

        public Task<bool> SendMail(Message message)
        {
            _logger.LogInformation("Sended Mail by Mandril");
            return Task.FromResult(true);
        }
    }
}