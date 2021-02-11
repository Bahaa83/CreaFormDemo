using CreaFormDemo.Entitys.Symptoms;
using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.IRepository
{
  public  interface IAdvisorRepository
    {

        Task<Advisor> CompletionAdvisorProfile(Advisor advisor);
        Task<Advisor> GetAdvisorByUserID(string userid);
        Task<Client> GetClientByID(string ID);
        Task<bool> Save();
        Task<IEnumerable<Client>> GetClientbyName(string name, string advisorID);
        Task<IEnumerable<Client>> GetClients(string advisorID);
        Task<IEnumerable<ClientSymptom>> GetClientSymtomAnsewr(string clientid);
        Task<IEnumerable<SymtomOverview>> GetSymtomOverview(string clientid);
        Task<User> GetUserByID(string id);


    }
}
