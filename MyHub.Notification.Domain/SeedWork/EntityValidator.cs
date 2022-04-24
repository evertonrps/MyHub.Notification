using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.SeedWork
{
    public abstract class EntityValidator<T> : AbstractValidator<T> where T : Entity<T>
    {
    }
}
