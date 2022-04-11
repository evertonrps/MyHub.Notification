using MyHub.Notification.Domain.Entities;

namespace MyHub.Notification.ExternalService.Interfaces.Strategy
{
    public interface IMailStrategy
    {
        Task<bool> SendMail(Message message);
    }
}