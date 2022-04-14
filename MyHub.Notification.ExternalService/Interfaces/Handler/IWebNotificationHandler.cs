using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.ExternalService.Interfaces.Handler
{
    public interface IWebNotificationHandler
    {
        ENotificationProvider NotificationProvider { get; }

        Task<ResponseEntity> SendWebNotification(Message message);
    }
}