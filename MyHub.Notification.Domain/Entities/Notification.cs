using MyHub.Notification.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.Entities
{
    public abstract class Notification
    {
        public string Email { get; set; }
        public string ClientID { get; set; }
        public string Message { get; set; }
        public ENotificationProvider? NotificationProvider { get; set; }
        public IEnumerable<ENotiticationType> NotificationType { get; set; }
    }
}
