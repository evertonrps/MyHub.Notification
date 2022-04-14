using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.Exceptions;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Interfaces.Strategy;

namespace MyHub.Notification.ExternalService.Services
{
    public class MailStrategy : IMailStrategy
    {
        private readonly IEnumerable<IMailHandler> _providers;

        public MailStrategy(IEnumerable<IMailHandler> providers)
        {
            _providers = providers;
        }

        public Task<ResponseEntity> SendMail(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendMail(message) ?? Task.FromResult(new ResponseEntity
            {
                Message = $"{message?.NotificationProvider?.GetDescription()} not support mail service",
                Success = false,                
                Type = ENotiticationType.Email,
                Provider = message?.NotificationProvider,
            });
            //?? throw new ServiceUnavailableException(message.NotificationProvider, $"{message?.NotificationProvider?.GetDescription()} not support mail service");
        }
    }
}