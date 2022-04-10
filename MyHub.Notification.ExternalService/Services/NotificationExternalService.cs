using Microsoft.Extensions.Options;
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.ExternalServices.Interfaces;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces;

namespace MyHub.Notification.ExternalService.Services
{
    public class NotificationExternalService : INotificationExternalService
    {
        private readonly IOptions<AppSettings> _configuration;
        private readonly IMailStrategy _mailStrategy;
        private readonly ENotificationProvider notificationProvider;

        public NotificationExternalService(IOptions<AppSettings> configuration ,IMailStrategy mailStrategy)
        {
            _configuration = configuration;
            _mailStrategy = mailStrategy;
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
            throw new NotImplementedException();
        }

        public Task<bool> SendSmsNotificationHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? notificationProvider;
            throw new NotImplementedException();
        }

        public Task<bool> SendWebNotificationHandler(Message message)
        {
            message.NotificationProvider = message.NotificationProvider ?? notificationProvider;
            throw new NotImplementedException();
        }
    }
}
