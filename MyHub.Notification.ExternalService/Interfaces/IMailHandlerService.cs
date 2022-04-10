using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.ExternalService.Interfaces
{
    public interface IMailHandlerService
    {
        ENotificationProvider NotificationProvider { get; }
        Task<bool> SendMail(Message message);
    }
}
