using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.Enuns
{
    public enum ENotiticationType
    {
        Invalid = 0,
        Email = 1,
        MobileNotification = 2,
        PushNotification = 3,
        WebNotification= 4,
        WhatsAppMessage = 5,
        All = 99
    }
}
