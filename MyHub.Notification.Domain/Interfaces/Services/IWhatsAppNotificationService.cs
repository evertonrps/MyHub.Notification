using MyHub.Notification.Domain.Entities;

namespace MyHub.Notification.Domain.Interfaces.Services
{
    public interface IWhatsAppNotificationService
    {
        Task<bool> SendWhatsAppMessage(Message message);
    }
}