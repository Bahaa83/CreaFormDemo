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
        Task<Advisor> CancelAdvisorAccount(int advisorID);
        Task<Advisor> GetAdvisorByID(int id);
        Task<bool> Save();
    }
}
