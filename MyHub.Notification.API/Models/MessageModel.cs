using MyHub.Notification.API.Models.Validators;
using MyHub.Notification.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace MyHub.Notification.API.Models
{
    public class MessageModel
    {
        public string Email { get; set; }
        public string ClientID { get; set; }
        public string Message { get; set; }

        [Range(1,999)]
        public ENotificationProvider? NotificationProvider { get; set; }

        [MinLength(1)]
        [MinimumElementsValue]        
        public IEnumerable<ENotiticationType>? NotificationType { get; set; }
    }
}
