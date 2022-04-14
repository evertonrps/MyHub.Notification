using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.ExternalService.Interfaces.Strategy
{
    public interface IMailStrategy
    {
        Task<ResponseEntity> SendMail(Message message);
    }
}