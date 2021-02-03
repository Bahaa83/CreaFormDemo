﻿using AutoMapper;
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
        private readonly IMapper imapper;

        public ClientRepository(CreaFormDBcontext db,IMapper imapper)
        {
            this.db = db;
            this.imapper = imapper;
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

        public async Task<Well_being> FillInWellBeing(Well_being model)
        {
            var result = await db.well_Beings.AddAsync(model);
            if (!await Save()) return null;
            return result.Entity;
        }

        public async Task<Client> GetClientByUserID(int ID)
        {
           
            var client = await db.clients.FirstOrDefaultAsync(x => x.UserID == ID);
            if (client == null) return null;
            return client;
        }

        public async Task<IEnumerable< Difficulty>> GetDifficultyValue()
        {
            var difficulty = await db.difficulties.ToListAsync();
            if (difficulty == null) return null;
            return difficulty;
        }

        public async Task<IEnumerable< Frequency>> GetFrequencyValue()
        {
            var frequency = await db.frequencies.ToListAsync();
            if (frequency == null) return null;
            return frequency;
        }

        public async Task<GeneralQuestions> updateGeneralQuestions(GeneralQuestions model)
        {
         
            var oldgeneralquestion = await db.generalQuestions.FirstOrDefaultAsync(x => x.ClientID == model.ID);
            if (oldgeneralquestion != null)
            {
                imapper.Map(model, oldgeneralquestion);
               await Save();
                return oldgeneralquestion;
            }
            else
            {
                return null;
            }
        }

        public async Task<Medicine> GetMedicineByUserID(int Userid)
        {
            var client = await db.clients.FirstOrDefaultAsync(x => x.UserID == Userid);
            var medicine = await db.medicines.FirstOrDefaultAsync(x => x.ClientID == client.ID);
            return medicine;
        }

        public async Task<SymptomsCategory> GetSymptomsQuesbycategory(int orderby)
        {
            var symtomcategori = await db.symptomsCategories.Include(x=>x.symptomQuestions).FirstOrDefaultAsync(x => x.OrderBy == orderby);
            if (symtomcategori == null) return null;
            return symtomcategori;
        }

        public async Task<User> GetUserByID(int Id)
        {
            var user = await db.users.FirstOrDefaultAsync(x => x.ID == Id);
            if (user == null) return null;
            return user;
        }

        public async Task<Well_being> GetWellbeingByUserid(int Userid)
        {
            var client = await GetClientByUserID(Userid);
            var wellbeing = await db.well_Beings.FirstOrDefaultAsync(x => x.ClientID == client.ID);
            return wellbeing;
        }
        public async Task<bool> Save()
        {
            return await db.SaveChangesAsync() >= 0 ? true : false;
        }

        
    }
}
