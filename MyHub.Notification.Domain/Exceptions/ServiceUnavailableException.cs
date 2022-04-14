using MyHub.Notification.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.Exceptions
{
    public class ServiceUnavailableException : Exception
    {
        public ENotificationProvider? Provider { get; }
        public ServiceUnavailableException()
        {
        }

        public ServiceUnavailableException(ENotificationProvider? provider, string? message) : base(message)
        {
            this.Provider = provider;   
        }

        public ServiceUnavailableException(ENotificationProvider? provider, string? message, Exception? innerException) : base(message, innerException)
        {
            this.Provider = provider;
        }

        protected ServiceUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
