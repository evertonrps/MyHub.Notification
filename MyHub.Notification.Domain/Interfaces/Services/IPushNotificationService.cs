﻿using MyHub.Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.Interfaces.Services
{
    public interface IPushNotificationService
    {
        Task<bool> SendPushNotification(Message message);
    }
}