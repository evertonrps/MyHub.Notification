using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.ExternalService.Interfaces.Handler
{
    public interface ISmsHandler
    {
        ENotificationProvider NotificationProvider { get; }

        Task<ResponseEntity> SendSMS(Message message);
    }
}