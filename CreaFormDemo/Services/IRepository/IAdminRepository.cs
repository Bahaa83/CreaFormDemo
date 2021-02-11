using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.IRepository
{
  public  interface IAdminRepository
    {
        Task<IEnumerable<Advisor>> GetAllAdvisors();
        Task<Advisor> CancelAdvisorAccount(string advisorID);
        Task<Advisor> GetAdvisorByID(string id);
        Task<bool> Save();
        Task<IEnumerable<Advisor>> GetAdvisorByName(string name);
    }
}
