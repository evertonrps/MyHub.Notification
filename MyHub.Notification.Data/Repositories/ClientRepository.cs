using MyHub.Notification.Domain.Entities;
using MyHub.Notification.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHub.Notification.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public async Task<Client> GetClientByAccount(int checkingAccount)
        {
            return new Client();
        }

        public async Task<string> GetMailByAccount(int checkingAccount)
        {
            return string.Empty;
        }
    }
}
