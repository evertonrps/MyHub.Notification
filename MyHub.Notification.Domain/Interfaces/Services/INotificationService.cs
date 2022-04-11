
using MyHub.Notification.Domain.Entities;

namespace MyHub.Notification.Domain.Interfaces.Services
{
    public interface INotificationService
    {
        Task<bool> SendNotification(Message message);
    }
}