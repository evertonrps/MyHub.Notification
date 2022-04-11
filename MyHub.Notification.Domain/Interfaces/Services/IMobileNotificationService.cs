using MyHub.Notification.Domain.Entities;

namespace MyHub.Notification.Domain.Interfaces.Services
{
    public interface IMobileNotificationService
    {
        Task<bool> SendSmsNotification(Message message);
    }
}