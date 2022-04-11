using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;

namespace MyHub.Notification.ExternalService.Interfaces.Handler
{
    public interface IWhatsAppHandler
    {
        ENotificationProvider NotificationProvider { get; }

        Task<bool> SendWhatsAppMessage(Message message);
    }
}