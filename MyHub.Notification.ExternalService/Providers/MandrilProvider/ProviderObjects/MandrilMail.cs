using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.ExternalService.Providers.MandrilProvider.ProviderObjects
{
    public class MandrilMail
    {
        public MandrilMail(string email, string subject, string body)
        {
            Email = email;
            Subject = subject;
            Body = body;
        }

        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
