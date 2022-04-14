﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException()
        {
        }

        public RecordNotFoundException(string? message) : base(message)
        {
        }

        public RecordNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RecordNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
