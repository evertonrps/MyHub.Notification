using MyHub.Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.ExternalService.Interfaces
{
    public interface IMarketingCloudExternalService: IMailHandlerService
    {        
        Task<bool> SendPush(Message message);
        Task<bool> SendSMS(Message message);
    }
}
