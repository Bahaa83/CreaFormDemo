﻿using CreaFormDemo.DtoModel.SymtomDtoModel;
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
    public class SymtomRepo : ISymtomRepo
    {
        private readonly CreaFormDBcontext db;

        public SymtomRepo(CreaFormDBcontext db)
        {
            this.db = db;
        }

        public async Task<bool> AddSymtomAnswer(Client client, SymtomAnswer model)
        {
            int totalt = model.Frequency + model.Difficulty;
            int symtomcategoryId = await GetSymtomCategoryID(model.SymtomText);
            if(totalt>0)
            {
                var compliteclient = new ClientSymptom()
                {
                    ClientID = client.ID,
                    SymtomCategoryID = symtomcategoryId,
                    Frequency = model.Frequency,
                    Difficulty = model.Difficulty,
                    SymtomText = model.SymtomText,
                    TotPsymtom = totalt,
                    Numberofsymptoms = 1
                };
                await db.clientSymptoms.AddAsync(compliteclient);
                return await Save();
            }
            else
            {
                var compliteclient = new ClientSymptom()
                {
                    ClientID = client.ID,
                    SymtomCategoryID = symtomcategoryId,
                    Frequency = model.Frequency,
                    Difficulty = model.Difficulty,
                    SymtomText = model.SymtomText,
                    TotPsymtom = totalt,
                    Numberofsymptoms = 0
                };
                await db.clientSymptoms.AddAsync(compliteclient);
                return await Save();
            }

            

        }

        private async Task<bool> Save()
        {
            return await db.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<int> GetSymtomCategoryID(string symtomtext)
        {
            int CategoryID = 0;
            if (!string.IsNullOrEmpty(symtomtext))
            {
                var symtom = await db.symptomQuestions.FirstOrDefaultAsync(x => x.FråganText == symtomtext);
                 CategoryID = symtom.SymptomsCategoryID;
                return CategoryID;
            }
            return CategoryID;
        }

       private ClientSymptom TotalFrequncyAndNumberOfSymtom(ClientSymptom clientSymptom)
        {
            if(clientSymptom.Frequency>0)
            {
                clientSymptom.TotPsymtom = (clientSymptom.Frequency + clientSymptom.Difficulty);
                clientSymptom.Numberofsymptoms = 1;
                return clientSymptom;
            }
            return clientSymptom;
            
        }
    }
}
