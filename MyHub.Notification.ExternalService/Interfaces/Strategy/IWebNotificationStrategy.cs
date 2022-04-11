using MyHub.Notification.Domain.Entities;

namespace MyHub.Notification.ExternalService.Interfaces.Strategy
{
    public interface IWebNotificationStrategy
    {
        Task<bool> SendWebNotification(Message message);
    }
}