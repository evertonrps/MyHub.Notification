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
        private readonly ENotificationProvider defaultMailProvider;
        private readonly ENotificationProvider defaultSMSProvider;
        private readonly ENotificationProvider defaultPushProvider;
        private readonly ENotificationProvider defaultWebNotificationProvider;
        private readonly ENotificationProvider defaultWhatsAppProvider;

        public NotificationExternalService(IOptions<AppSettings> configuration, IMailStrategy mailStrategy, ISmsStrategy smsStrategy, IPushStrategy pushStrategy, IWhatsAppStrategy whatsAppStrategy, IWebNotificationStrategy webNotificationStrategy)
        {
            _configuration = configuration;
            _mailStrategy = mailStrategy;
            _smsStrategy = smsStrategy;
            _pushStrategy = pushStrategy;
            _whatsAppStrategy = whatsAppStrategy;
            _webNotificationStrategy = webNotificationStrategy;

            defaultMailProvider = (ENotificationProvider)_configuration.Value.DefaultMailProvider;
            defaultSMSProvider = (ENotificationProvider)_configuration.Value.DefaultSMSProvider;
            defaultPushProvider = (ENotificationProvider)_configuration.Value.DefaultPushProvider;
            defaultWebNotificationProvider = (ENotificationProvider)_configuration.Value.DefaultWebNotificationProvider;
            defaultWhatsAppProvider = (ENotificationProvider)_configuration.Value.DefaultWhatsAppProvider;
        }

        public Task<ResponseEntity> SendMailHandler(Message message)
        {
            if (message.NotificationType != null)
                return _mailStrategy.SendMail(message);

            var messageCopy = message.ShallowCopy().SetProvider(defaultMailProvider);            
            return _mailStrategy.SendMail(messageCopy);
        }

        public Task<ResponseEntity> SendPushNotificationHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? defaultPushProvider;
            return _pushStrategy.SendPushNotification(message);
        }

        public Task<ResponseEntity> SendSmsNotificationHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? defaultSMSProvider;
            return _smsStrategy.SendSMS(message);
        }

        public Task<ResponseEntity> SendWebNotificationHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? defaultWebNotificationProvider;
            return _webNotificationStrategy.SendWebNotification(message);
        }

        public Task<ResponseEntity> SendWhatsAppMessageHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? defaultWhatsAppProvider;
            return _whatsAppStrategy.SendWhatsAppMessage(message);
        }
    }
}