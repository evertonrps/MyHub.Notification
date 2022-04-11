using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;

namespace MyHub.Notification.ExternalService.Interfaces.Handler
{
    public interface IWebNotificationHandler
    {
        ENotificationProvider NotificationProvider { get; }

        Task<bool> SendWebNotification(Message message);
    }
}