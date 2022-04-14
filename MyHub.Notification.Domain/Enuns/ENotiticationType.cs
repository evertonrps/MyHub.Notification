using System.ComponentModel;

namespace MyHub.Notification.Domain.Enuns
{
    public enum ENotiticationType
    {
        [Description("Invalid")]
        Invalid = 0,

        [Description("Mail")]
        Email = 1,

        [Description("SMS")]
        MobileNotification = 2,

        [Description("Push Notification")]
        PushNotification = 3,

        [Description("Web Notification")]
        WebNotification = 4,

        [Description("WhatsApp Message")]
        WhatsAppMessage = 5,

        [Description("All services")]
        All = 99
    }
}