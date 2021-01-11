using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly CreaFormDBcontext dB;

        public AdminRepository(CreaFormDBcontext DB)
        {
            dB = DB;
        }

        public async Task<Advisor> CancelAdvisorAccount(int  advisorID)
        {
            var result = await GetAdvisorByID(advisorID);
            if (result == null) return null;
          var user= await GetUserByID(result.UserID);
            if (user == null) return null;
            //user.IsBlocked = true;
            if (!await Save()) return null;
            return result;
        }
        public async Task<User> GetUserByID(int id)
        {
            var user = await dB.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return null;
            return user;
        }
        public async Task<Advisor> GetAdvisorByID(int id)
        {
            var advisor = await dB.advisors.FirstOrDefaultAsync(x => x.ID == id);
            if (advisor == null) return null;
            return advisor;
        }

        public async Task<IEnumerable<Advisor>> GetAllAdvisors()
        {

            return await dB.advisors.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await dB.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
