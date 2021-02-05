using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Symptoms;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.Repository
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly CreaFormDBcontext db;

        public AdvisorRepository(CreaFormDBcontext db)
        {
            this.db = db;
        }

        public async Task<Advisor> CompletionAdvisorProfile(Advisor advisor)
        {
            var _advisor = await db.advisors.AddAsync(advisor);

            if (!await Save()) return null;
            return _advisor.Entity;
        }

        public async Task<Advisor> GetAdvisorByUserID(int userid)
        {
            var advisor = await db.advisors.FirstOrDefaultAsync(x => x.UserID == userid);
            if (advisor == null) return null;
            return advisor;
        }

        public async Task<IEnumerable<Client>> GetClientbyName(string name,int advisorID)
        {
            
             return await db.clients.Where(x =>x.Firstname.Equals(name.ToLower()) && x.AdvisorID==advisorID).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetClients(int advisorID)
        {
            return  await db.clients.Where(x => x.AdvisorID == advisorID).ToListAsync();
          
        }

        public async Task<IEnumerable<ClientSymptom>> GetClientSymtomAnsewr(int clientid)
        {
            IEnumerable<ClientSymptom> clientsymtoms = await db.clientSymptoms.
                Where(x => x.ClientID == clientid).OrderBy(x=>x.SymtomCategoryID).ToListAsync();
            if (clientsymtoms == null) return null;
            return clientsymtoms;

            
        }

        public async Task<IEnumerable<SymtomOverview>>GetSymtomOverview(int clientid)
        {
            var symtomsviews = new List<SymtomOverview>();
            var clientsymtomanswer = await GetClientSymtomAnsewr(clientid);
            //var categorys = await db.symptomsCategories.OrderBy(x=>x.OrderBy).ToListAsync();

            var Symtomoverview = new SymtomOverview();


            for (int i = 1; i < 15; i++)
            {
                foreach (var item in clientsymtomanswer)
                {
                if ( item.SymtomCategoryID == i)
                    {
                        Symtomoverview.SymtomCategoryID = item.SymtomCategoryID;
                        Symtomoverview.TotalFrequency += item.Frequency;
                        Symtomoverview.TotalDifficulty += item.Difficulty;
                        Symtomoverview.totalNumberofsymptoms += item.Numberofsymptoms;
                    }
                    symtomsviews.Add(Symtomoverview);
                }
               
            }

            return symtomsviews;

        }

        public async Task<bool> Save()
        {
            return await db.SaveChangesAsync() >= 0 ? true : false;
        }

       
    }
}
