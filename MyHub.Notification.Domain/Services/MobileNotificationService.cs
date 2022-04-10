using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.ExternalServices.Interfaces;
using MyHub.Notification.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.Services
{
    public class MobileNotificationService : IMobileNotificationService
    {
        private readonly INotificationExternalService _notificationExternalService;

        public MobileNotificationService(INotificationExternalService notificationExternalService)
        {
            _notificationExternalService = notificationExternalService;
        }
        public Task<bool> SendSmsNotification(Message message)
        {
            return _notificationExternalService.SendSmsNotificationHandler(message);
        }
    }
}
