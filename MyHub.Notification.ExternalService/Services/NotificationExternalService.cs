using Microsoft.Extensions.Options;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.ExternalServices.Interfaces;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Strategy;

namespace MyHub.Notification.ExternalService.Services
{
    public class NotificationExternalService : INotificationExternalService
    {
        private readonly IOptions<AppSettings> _configuration;
        private readonly IMailStrategy _mailStrategy;
        private readonly ISmsStrategy _smsStrategy;
        private readonly IPushStrategy _pushStrategy;
        private readonly IWhatsAppStrategy _whatsAppStrategy;
        private readonly IWebNotificationStrategy _webNotificationStrategy;
        private readonly ENotificationProvider notificationProvider;

        public NotificationExternalService(IOptions<AppSettings> configuration, IMailStrategy mailStrategy, ISmsStrategy smsStrategy, IPushStrategy pushStrategy, IWhatsAppStrategy whatsAppStrategy, IWebNotificationStrategy webNotificationStrategy)
        {
            _configuration = configuration;
            _mailStrategy = mailStrategy;
            _smsStrategy = smsStrategy;
            _pushStrategy = pushStrategy;
            _whatsAppStrategy = whatsAppStrategy;
            _webNotificationStrategy = webNotificationStrategy;
            notificationProvider = (ENotificationProvider)_configuration.Value.DefaultMailProvider;
        }

        public Task<bool> SendMailHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? notificationProvider;

            return _mailStrategy.SendMail(message);
        }

        public Task<bool> SendPushNotificationHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? notificationProvider;
            return _pushStrategy.SendPushNotification(message);
        }

        public Task<bool> SendSmsNotificationHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? notificationProvider;
            return _smsStrategy.SendSMS(message);
        }

        public Task<bool> SendWebNotificationHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? notificationProvider;
            return _webNotificationStrategy.SendWebNotification(message);
        }

        public Task<bool> SendWhatsAppMessageHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? notificationProvider;
            return _whatsAppStrategy.SendWhatsAppMessage(message);
        }
    }
}