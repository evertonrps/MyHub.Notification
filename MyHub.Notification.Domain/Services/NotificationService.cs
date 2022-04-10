using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.services
{
    public class NotificationService : INotificationService
    {
        private readonly IMailNotificationService _mailNotificationService;
        private readonly IMobileNotificationService _mobileNotificationService;
        private readonly IPushNotificationService _pushNotificationService;
        private readonly IWebNotificationService _webNotificationService;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(IMailNotificationService mailNotificationService, 
                                   IMobileNotificationService mobileNotificationService, 
                                   IPushNotificationService pushNotificationService,
                                   IWebNotificationService webNotificationService,
                                   ILogger<NotificationService> logger)
        {
            _mailNotificationService = mailNotificationService;
            _mobileNotificationService = mobileNotificationService;
            _pushNotificationService = pushNotificationService;
            _webNotificationService = webNotificationService;
            _logger = logger;
        }

        public Task<bool> SendNotification(Message message)
        {
            ///TODO validar envio ALL
            ///WhatsApp Message
            foreach (var item in message.NotificationType)
            {
                switch (item)
                {
                    case Enuns.ENotiticationType.Invalid:
                        _logger.LogError("Invalid notification type");
                        break;
                    case Enuns.ENotiticationType.Email:
                        //Send Mail
                        _mailNotificationService.SendMail(message);
                        break;
                    case Enuns.ENotiticationType.MobileNotification:
                        //Send SMS
                        _mobileNotificationService.SendSmsNotification(message);
                        break;
                    case Enuns.ENotiticationType.PushNotification:
                        //Send Push
                        _pushNotificationService.SendPushNotification(message);
                        break;
                    case Enuns.ENotiticationType.WebNotification:
                        //Send Web
                        _webNotificationService.SendWebNotification(message);
                        break;
                    case Enuns.ENotiticationType.All:
                        //Send everything
                        break;
                    default:
                        _logger.LogError("Unknown notification type");
                        break;
                }
            }
            return Task.FromResult(true);
        }
    }
}
