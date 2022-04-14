using System.ComponentModel;

namespace MyHub.Notification.Domain.Enuns
{
    public enum ENotificationProvider
    {
        [Description("Invalid")]
        Invalid = 0,

        [Description("Mandril")]
        Mandril = 1,

        [Description("HubSpot")]
        HubSpot = 2,

        [Description("One Signal")]
        OneSignal = 3,

        [Description("Firebase")]
        Firebase = 4,

        [Description("Marketing Cloud")]
        MarketingCloud = 5
    }
}