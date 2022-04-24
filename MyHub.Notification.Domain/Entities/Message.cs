using MyHub.Notification.Domain.Enuns;
using MyHub.Notification.Domain.SeedWork;

namespace MyHub.Notification.Domain.Entities
{
    public class Message : Entity<Message>  //: Notification
    {

        public string? Email { get; private set; }
        public string? ClientID { get; private set; }
        public string? BodyMessage { get; private set; }
        public string? Subject { get; private set; }
        public string? Template { get; private set; }
        public ENotificationProvider? NotificationProvider { get; private set; }
        public IEnumerable<ENotiticationType>? NotificationType { get; private set; }

        private Message(string? email, string? clientID, string? bodyMessage, string? subject, string? template, ENotificationProvider? notificationProvider, IEnumerable<ENotiticationType>? notificationType)
        {
            Email = email;
            ClientID = clientID;
            BodyMessage = bodyMessage;
            Subject = subject;
            Template = template;
            NotificationProvider = notificationProvider;
            NotificationType = notificationType;
        }

        public static Message Factory(string? email, string? clientID, string? bodyMessage, string? subject, string? template, ENotificationProvider? notificationProvider, IEnumerable<ENotiticationType>? notificationType)
        {
            var message = new Message(email, clientID, bodyMessage, subject, template, notificationProvider, notificationType);
            message.ValidateNow(new MessageValidator(), message);
            return message;
        }

        public Message ShallowCopy()
        {
            return (Message)this.MemberwiseClone();
        }

        public Message SetProvider(ENotificationProvider defaultMailProvider)
        {
            NotificationProvider = defaultMailProvider;
            return this;
        }

        public static object Factory(string? email, string? clientID, string? message, object subject, string? template, ENotificationProvider? notificationProvider, IEnumerable<ENotiticationType>? notificationType)
        {
            throw new NotImplementedException();
        }
    }
}