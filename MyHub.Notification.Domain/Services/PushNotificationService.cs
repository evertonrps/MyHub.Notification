using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.ExternalServices.Interfaces;
using MyHub.Notification.Domain.Interfaces.Services;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.Domain.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly INotificationExternalService _notificationExternalService;

        public PushNotificationService(INotificationExternalService notificationExternalService)
        {
            _notificationExternalService = notificationExternalService;
        }

        public Task<ResponseEntity> SendPushNotification(Message message)
        {
            return _notificationExternalService.SendPushNotificationHandler(message);
        }
    }
}