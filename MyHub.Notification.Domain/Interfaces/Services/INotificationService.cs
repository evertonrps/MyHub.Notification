
using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.Domain.Interfaces.Services
{
    public interface INotificationService
    {
        Task<List<ResponseEntity>> SendNotification(Message message);
    }
}