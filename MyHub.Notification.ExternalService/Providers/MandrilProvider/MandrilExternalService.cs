using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.ExternalService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.ExternalService.Providers.MandrilProvider
{
    public class MandrilExternalService : IMailHandlerService
    {
        private readonly ILogger<MandrilExternalService> _logger;

        public ENotificationProvider NotificationProvider => ENotificationProvider.Mandril;
        public MandrilExternalService(ILogger<MandrilExternalService> logger)
        {
            _logger = logger;
        }

        public Task<bool> SendMail(Message message)
        {
            _logger.LogInformation("Sended by Mandril");
            return Task.FromResult(true);
        }
    }
}
