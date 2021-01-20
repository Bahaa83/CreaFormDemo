using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.IRepository
{
  public  interface IClientRepository
    {
        Task<Client> CompletionClientProfile(Client client);
        Task<User> GetUserByID(int ID);
        Task<Client> GetClientByUserID(int ID);
        Task<bool> Save();
    }
}
