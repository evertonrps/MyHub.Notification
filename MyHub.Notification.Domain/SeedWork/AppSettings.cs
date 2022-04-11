namespace MyHub.Notification.Domain.SeedWork
{
    public class AppSettings
    {
        public int DefaultMailProvider { get; set; }
        public int DefaultSMSProvider { get; set; }
        public int DefaultPushProvider { get; set; }
        public int DefaultWebNotificationProvider { get; set; }
        public int DefaultWhatsAppProvider { get; set; }
    }
}