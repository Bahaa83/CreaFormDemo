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
        Task<bool> Save();
        Task<IEnumerable<Client>> GetClientbyName(string name, int advisorID);
        Task<IEnumerable<Client>> GetClients(int advisorID);


    }
}
