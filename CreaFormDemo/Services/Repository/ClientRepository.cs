using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Clientprofile;
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
    public class ClientRepository : IClientRepository
    {
        private readonly CreaFormDBcontext db;

        public ClientRepository(CreaFormDBcontext db)
        {
            this.db = db;
        }
        public async Task<Client> CompletionClientProfile( Client client)
        {
            var result = await db.clients.AddAsync(client);
            if (!await Save()) return null;
            return result.Entity;
        }

        public async Task<GeneralQuestions> FillInTheGeneralQuestions(GeneralQuestions profile)
        {
            var result = await db.generalQuestions.AddAsync(profile);
            if (!await Save()) return null;
            return result.Entity;
        }

        public async Task<Medicine> FillInTheMedicineInformations(Medicine medicine)
        {
            var result = await db.medicines.AddAsync(medicine);
            if (!await Save()) return null;
            return result.Entity;
        }

        public async Task<Client> GetClientByUserID(int ID)
        {
            var client = await db.clients.FirstOrDefaultAsync(x => x.UserID == ID);
            if (client == null) return null;
            return client;
        }

        public async Task<GeneralQuestions> GetGeneralQuestionsByUserID(int userid)
        {
            var client = await GetClientByUserID(userid);
            var generalquestion = await db.generalQuestions.FirstOrDefaultAsync(x => x.ClientID == client.ID);
            if (generalquestion != null)
            {
                return generalquestion;
            }
            else
            {
                return null;
            }
        }

        public async Task<SymptomsCategory> GetSymptomsQuesbycategory(int orderby)
        {
            var symtomCategori = await db.symptomsCategories.Include(x => x.symptomQuestions).FirstOrDefaultAsync(x => x.OrderBy == orderby);
            return symtomCategori;
        }

        public async Task<User> GetUserByID(int Id)
        {
            var user = await db.users.FirstOrDefaultAsync(x => x.ID == Id);
            if (user == null) return null;
            return user;
        }

        public async Task<bool> Save()
        {
            return await db.SaveChangesAsync() >= 0 ? true : false;
        }

        
    }
}
