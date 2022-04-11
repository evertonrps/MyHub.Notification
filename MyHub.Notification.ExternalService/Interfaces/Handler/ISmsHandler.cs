using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;

namespace MyHub.Notification.ExternalService.Interfaces.Handler
{
    public interface ISmsHandler
    {
        ENotificationProvider NotificationProvider { get; }

        Task<bool> SendSMS(Message message);
    }
}