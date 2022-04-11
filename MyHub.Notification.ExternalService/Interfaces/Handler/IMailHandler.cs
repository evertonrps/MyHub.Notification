using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;

namespace MyHub.Notification.ExternalService.Interfaces.Handler
{
    public interface IMailHandler
    {
        ENotificationProvider NotificationProvider { get; }

        Task<bool> SendMail(Message message);
    }
}