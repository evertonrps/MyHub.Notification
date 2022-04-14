using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.ExternalServices.Interfaces;
using MyHub.Notification.Domain.Interfaces.Services;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.Domain.Services
{
    public class WhatsAppNotificationService : IWhatsAppNotificationService
    {
        private readonly INotificationExternalService _notificationExternalService;

        public WhatsAppNotificationService(INotificationExternalService notificationExternalService)
        {
            _notificationExternalService = notificationExternalService;
        }

        public Task<ResponseEntity> SendWhatsAppMessage(Message message)
        {
            return _notificationExternalService.SendWhatsAppMessageHandler(message);
        }
    }
}