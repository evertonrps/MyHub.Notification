using MyHub.Notification.Domain.Entities;

namespace MyHub.Notification.Domain.ExternalServices.Interfaces
{
    public interface INotificationExternalService
    {
        Task<bool> SendWebNotificationHandler(Message message);

        Task<bool> SendPushNotificationHandler(Message message);

        Task<bool> SendMailHandler(Message message);

        Task<bool> SendSmsNotificationHandler(Message message);

        Task<bool> SendWhatsAppMessageHandler(Message message);
    }
}