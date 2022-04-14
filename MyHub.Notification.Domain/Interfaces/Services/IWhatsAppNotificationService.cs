using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.Domain.Interfaces.Services
{
    public interface IWhatsAppNotificationService
    {
        Task<ResponseEntity> SendWhatsAppMessage(Message message);
    }
}