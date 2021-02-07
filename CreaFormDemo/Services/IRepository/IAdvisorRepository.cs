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
        Task<Advisor> GetAdvisorByUserID(int userid);
        Task<Client> GetClientByID(int ID);
        Task<bool> Save();
        Task<IEnumerable<Client>> GetClientbyName(string name, int advisorID);
        Task<IEnumerable<Client>> GetClients(int advisorID);
        Task<IEnumerable<ClientSymptom>> GetClientSymtomAnsewr(int clientid);
        Task<IEnumerable<SymtomOverview>> GetSymtomOverview(int clientid);


    }
}
