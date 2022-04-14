using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Interfaces.Strategy;

namespace MyHub.Notification.ExternalService.Services
{
    public class SmsStrategy : ISmsStrategy
    {
        private readonly IEnumerable<ISmsHandler> _providers;

        public SmsStrategy(IEnumerable<ISmsHandler> providers)
        {
            _providers = providers;
        }

        public Task<ResponseEntity> SendSMS(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendSMS(message)
                ?? Task.FromResult(new ResponseEntity
                {
                    Message = $"{message?.NotificationProvider?.GetDescription()} not support SMS service",
                    Success = false,
                    Type = ENotiticationType.MobileNotification,
                    Provider = message?.NotificationProvider
                });
            //throw new ServiceUnavailableException(message.NotificationProvider,$"{message?.NotificationProvider?.GetDescription()} not support SMS service");
        }
    }
}