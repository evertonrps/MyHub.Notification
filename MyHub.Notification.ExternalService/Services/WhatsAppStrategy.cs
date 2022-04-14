using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.ExternalService.Interfaces.Handler;
using MyHub.Notification.ExternalService.Interfaces.Strategy;

namespace MyHub.Notification.ExternalService.Services
{
    public class WhatsAppStrategy : IWhatsAppStrategy
    {
        private readonly IEnumerable<IWhatsAppHandler> _providers;

        public WhatsAppStrategy(IEnumerable<IWhatsAppHandler> providers)
        {
            _providers = providers;
        }

        public Task<ResponseEntity> SendWhatsAppMessage(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendWhatsAppMessage(message)
                                 ?? Task.FromResult(new ResponseEntity
                                 {
                                     Message = $"{message?.NotificationProvider?.GetDescription()} not support whatsapp service",
                                     Success = false,
                                     Type = ENotiticationType.WhatsAppMessage,
                                     Provider = message?.NotificationProvider
                                 });
            //?? throw new ServiceUnavailableException(message.NotificationProvider,$"{message?.NotificationProvider?.GetDescription()} not support whatsapp service");
        }
    }
}