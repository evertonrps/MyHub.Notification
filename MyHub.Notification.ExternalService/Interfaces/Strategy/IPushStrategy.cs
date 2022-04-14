using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.ExternalService.Interfaces.Strategy
{
    public interface IPushStrategy
    {
        Task<ResponseEntity> SendPushNotification(Message message);
    }
}