using MyHub.Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.ExternalService.Interfaces
{
    public interface IHubSpotExternalService: IMailHandlerService
    {        
        Task<bool> SendSMS(Message message);
        Task<bool> SendWebNotification(Message message);
        Task<bool> SendWhatsAppMessage(Message message);
    }
}
