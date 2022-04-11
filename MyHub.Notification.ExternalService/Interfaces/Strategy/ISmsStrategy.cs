using MyHub.Notification.Domain.Entities;

namespace MyHub.Notification.ExternalService.Interfaces.Strategy
{
    public interface ISmsStrategy
    {
        Task<bool> SendSMS(Message message);
    }
}