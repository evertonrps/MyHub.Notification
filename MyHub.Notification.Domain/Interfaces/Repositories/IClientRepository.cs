using MyHub.Notification.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<string> GetMailByAccount(int checkingAccount);
        Task<Client> GetClientByAccount(int checkingAccount);
    }
}
