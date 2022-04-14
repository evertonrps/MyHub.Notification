using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.Domain.ExternalServices.Interfaces
{
    public interface INotificationExternalService
    {
        Task<ResponseEntity> SendWebNotificationHandler(Message message);

        Task<ResponseEntity> SendPushNotificationHandler(Message message);

        Task<ResponseEntity> SendMailHandler(Message message);

        Task<ResponseEntity> SendSmsNotificationHandler(Message message);

        Task<ResponseEntity> SendWhatsAppMessageHandler(Message message);
    }
}