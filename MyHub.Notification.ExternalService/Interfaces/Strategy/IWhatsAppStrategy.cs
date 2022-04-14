using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.ExternalService.Interfaces.Strategy
{
    public interface IWhatsAppStrategy
    {
        Task<ResponseEntity> SendWhatsAppMessage(Message message);
    }
}