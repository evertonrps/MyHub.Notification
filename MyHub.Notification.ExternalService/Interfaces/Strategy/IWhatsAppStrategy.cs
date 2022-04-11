using MyHub.Notification.Domain.Entities;

namespace MyHub.Notification.ExternalService.Interfaces.Strategy
{
    public interface IWhatsAppStrategy
    {
        Task<bool> SendWhatsAppMessage(Message message);
    }
}