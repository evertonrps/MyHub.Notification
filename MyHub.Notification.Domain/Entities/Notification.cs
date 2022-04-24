using MyHub.Notification.Domain.Enuns;

namespace MyHub.Notification.Domain.Entities
{
    public abstract class Notification
    {
        public string? Email { get; set; }
        public string? ClientID { get; set; }
        public string? Message { get; set; }
        public string? Subject { get; set; }
        public string? Template { get; set; }
        public ENotificationProvider? NotificationProvider { get; set; }
        public IEnumerable<ENotiticationType>? NotificationType { get; set; }
    }
}