using MyHub.Notification.Domain.Entities;
using MyHub.Notification.ExternalService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.ExternalService.Providers.FirebaseProvider
{
    public class FirebaseExternalService : IFirebaseExternalService
    {
        public Task<bool> SendPush(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
