using Microsoft.Extensions.Logging;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Exceptions;
using MyHub.Notification.Domain.Interfaces.Services;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.Domain.services
{
    public class NotificationService : INotificationService
    {
        private readonly IMailNotificationService _mailNotificationService;
        private readonly IMobileNotificationService _mobileNotificationService;
        private readonly IPushNotificationService _pushNotificationService;
        private readonly IWebNotificationService _webNotificationService;
        private readonly IWhatsAppNotificationService _whatsAppNotificationService;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(IMailNotificationService mailNotificationService,
                                   IMobileNotificationService mobileNotificationService,
                                   IPushNotificationService pushNotificationService,
                                   IWebNotificationService webNotificationService,
                                   IWhatsAppNotificationService whatsAppNotificationService,
                                   ILogger<NotificationService> logger)
        {
            _mailNotificationService = mailNotificationService;
            _mobileNotificationService = mobileNotificationService;
            _pushNotificationService = pushNotificationService;
            _webNotificationService = webNotificationService;
            _whatsAppNotificationService = whatsAppNotificationService;
            _logger = logger;
        }

        public async Task<List<ResponseEntity>> SendNotification(Message message)
        {
            ///TODO validar envio ALL
            List<ResponseEntity> results = new List<ResponseEntity>();
            ///WhatsApp Message
            foreach (var item in message.NotificationType)
            {
                switch (item)
                {
                    case Enuns.ENotiticationType.Invalid:
                        _logger.LogError("Invalid notification type");
                        break;

                    case Enuns.ENotiticationType.Email:
                        {
                            //Send Mail
                            var sendMail = await _mailNotificationService.SendMail(message);
                            results.Add(sendMail);
                            break;
                        }
                    case Enuns.ENotiticationType.MobileNotification:
                        {
                            //Send SMS
                            var sendSms = await _mobileNotificationService.SendSmsNotification(message);
                            results.Add(sendSms);
                            break;
                        }

                    case Enuns.ENotiticationType.PushNotification:
                        {
                            //Send Push
                            var sendPUsh = await _pushNotificationService.SendPushNotification(message);
                            results.Add(sendPUsh);
                            break;
                        }

                    case Enuns.ENotiticationType.WebNotification:
                        {
                            //Send Web
                            var senWebNotification = await _webNotificationService.SendWebNotification(message);
                            results.Add(senWebNotification);
                            break;
                        }

                    case Enuns.ENotiticationType.WhatsAppMessage:
                        {
                            var whatsApp = await _whatsAppNotificationService.SendWhatsAppMessage(message);
                            results.Add(whatsApp);
                            break;
                        }
                    case Enuns.ENotiticationType.All:
                        //Send everything
                        break;
                    default:
                        {
                            _logger.LogError("Unknown notification type");
                            results.Add(new ResponseEntity { Type = item, Success = false, Message = "Unknown notification type" });
                            break;
                        }
                }
            }
            if (results.Where(x => !x.Success).Any())
                throw new SendException("Falha durante o envio", results);
            return results;
        }
    }
}