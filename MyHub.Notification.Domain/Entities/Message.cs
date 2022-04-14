using MyHub.Notification.Domain.Enuns;

namespace MyHub.Notification.Domain.Entities
{
    public class Message : Notification
    {
        public Message ShallowCopy()
        {
            return (Message)this.MemberwiseClone();
        }

        public Message SetProvider(ENotificationProvider defaultMailProvider)
        {
            NotificationProvider = defaultMailProvider;
            return this;
        }
    }
}