using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.Enuns
{
    public enum ENotificationProvider
    {
        Invalid = 0,
        Mandril = 1,
        HubSpot = 2,
        OneSignal = 3,
        Firebase = 4,
        MarketingCloud = 5
    }
}
