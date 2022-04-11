using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;

namespace MyHub.Notification.ExternalService.Interfaces.Handler
{
    public interface IPushNotificationHandler
    {
        ENotificationProvider NotificationProvider { get; }

        Task<bool> SendPushNotification(Message message);
    }
}