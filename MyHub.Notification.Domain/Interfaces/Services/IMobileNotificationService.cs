using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.Domain.Interfaces.Services
{
    public interface IMobileNotificationService
    {
        Task<ResponseEntity> SendSmsNotification(Message message);
    }
}