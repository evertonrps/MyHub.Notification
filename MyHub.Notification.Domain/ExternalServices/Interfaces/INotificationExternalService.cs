using MyHub.Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.ExternalServices.Interfaces
{
    public interface INotificationExternalService
    {
        Task<bool> SendWebNotificationHandler(Message message);
        Task<bool> SendPushNotificationHandler(Message message);
        Task<bool> SendMailHandler(Message message);
        Task<bool> SendSmsNotificationHandler(Message message);
    }
}
