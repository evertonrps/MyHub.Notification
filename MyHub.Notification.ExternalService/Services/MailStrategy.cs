using MyHub.Notification.Domain.Entities;
using MyHub.Notification.ExternalService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.ExternalService.Services
{
    public class MailStrategy : IMailStrategy
    {
        private readonly IEnumerable<IMailHandlerService> _providers;

        public MailStrategy(IEnumerable<IMailHandlerService> providers)
        {
            _providers = providers; 
        }
        public Task<bool> SendMail(Message message)
        {
            return _providers.FirstOrDefault(x => x.NotificationProvider == message.NotificationProvider)?.SendMail(message) ?? throw new ArgumentNullException(nameof(message));
        }
    }
}
