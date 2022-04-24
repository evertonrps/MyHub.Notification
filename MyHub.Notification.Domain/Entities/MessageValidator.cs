using FluentValidation;
using MyHub.Notification.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.Entities
{
    public class MessageValidator : EntityValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email adress required")
                .Length(2, 150).WithMessage("The email address must contain 2 to 20 characters");

            RuleFor(msg => msg.Template).NotNull().When(msg => msg.NotificationProvider == Enuns.ENotificationProvider.HubSpot && msg.NotificationType.Contains(Enuns.ENotiticationType.Email)).WithMessage("Hubspot requires template for email");
        }
    }
}
