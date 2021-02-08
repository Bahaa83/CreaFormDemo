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
        private readonly ISymtomRepo symtomRepo;

        public AdvisorRepository(CreaFormDBcontext db, ISymtomRepo symtomRepo)
        {
            this.db = db;
            this.symtomRepo = symtomRepo;
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

        public async Task<Client> GetClientByID(int id)
        {
            var client = await db.clients.FirstOrDefaultAsync(x => x.ID == id);
            if (client != null) return client;
            return null;
        }

        public async Task<IEnumerable<Client>> GetClientbyName(string name, int advisorID)
        {

            return await db.clients.Where(x => x.Firstname.Equals(name.ToLower()) && x.AdvisorID == advisorID).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetClients(int advisorID)
        {
            return await db.clients.Where(x => x.AdvisorID == advisorID).ToListAsync();

        }

        public async Task<IEnumerable<ClientSymptom>> GetClientSymtomAnsewr(int clientid)
        {
            IEnumerable<ClientSymptom> clientsymtoms = await db.clientSymptoms
                .Include(cs => cs.symptomsCategory)
                .Where(x => x.ClientID == clientid).OrderBy(x => x.SymtomCategoryID).ToListAsync(); ;
            if (clientsymtoms == null) return null;
            return clientsymtoms;


        }

        public async Task<IEnumerable<SymtomOverview>> GetSymtomOverview(int clientid)
        {
            var symtomsviews = new List<SymtomOverview>();
            var clientsymtomanswer = await GetClientSymtomAnsewr(clientid);
            //  var categorys = await db.symptomsCategories.OrderBy(x => x.OrderBy).ToListAsync();
            // var Symtomoverview = new SymtomOverview();
            //clientsymtomanswer
            //    .Join(db.symptomsCategories, c => c.SymtomCategoryID, s => s.ID, (c, s) => new
            //    {
            //        CategoryName = s.Name,
            //        c.SymtomText
            //    });
            // Extension Methods , Lambda Expression 
            //T-SQL >> Transact Sql
            //select s.Name s CategoryName , c.SystomText from symtomanswer as s
            //join  symptomsCategories as c on  s.SymtomCategoryID = c.Id|

            var overview = clientsymtomanswer.GroupBy(c => c.symptomsCategory.Name, (key, result) =>
               new SymtomOverview
               {
                   SymtomCategory = key,
                   TotalFrequency = result.Sum(r => r.Frequency),
                   TotalDifficulty = result.Sum(r => r.Difficulty),
                   totalNumberofsymptoms = result.Sum(r => r.Numberofsymptoms)
               });

            //for (int i = 0; i < categorys.Count(); i++)
            //{
            //    foreach (var item in clientsymtomanswer)
            //    {
            //        if (item.SymtomCategoryID == categorys[i].ID)
            //        {

            //            Symtomoverview.SymtomCategory = await symtomRepo.GetSymtomCategoryName(item.SymtomCategoryID);
            //            Symtomoverview.TotalFrequency += item.Frequency;
            //            Symtomoverview.TotalDifficulty += item.Difficulty;
            //            Symtomoverview.totalNumberofsymptoms += item.Numberofsymptoms;
            //        }

            //    }
            //    symtomsviews.Add(Symtomoverview);
            //    Symtomoverview = new SymtomOverview();
            //}

            // return symtomsviews;
            return overview;
        }

        public async Task<bool> Save()
        {
            return await db.SaveChangesAsync() >= 0 ? true : false;
        }


    }
}
