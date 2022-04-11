using MyHub.Notification.Domain.Entities;

namespace MyHub.Notification.ExternalService.Interfaces.Strategy
{
    public interface IPushStrategy
    {
        Task<bool> SendPushNotification(Message message);
    }
}