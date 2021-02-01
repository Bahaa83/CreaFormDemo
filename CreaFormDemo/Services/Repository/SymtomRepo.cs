using CreaFormDemo.DtoModel.SymtomDtoModel;
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

        public async Task<bool> AddSymtomAnswer(ClientSymptom clientSymptom)
        {
            //var compliteclient = TotalFrequncyAndNumberOfSymtom(clientSymptom);
                await db.clientSymptoms.AddAsync(clientSymptom);
                return await Save();
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
                var symtom = await db.symptomQuestions.FirstOrDefaultAsync(x => x.FråganText.Equals(symtomtext));

                 CategoryID = symtom.SymptomsCategoryID;
                return CategoryID;
            }
            return CategoryID;
        }

       private ClientSymptom TotalFrequncyAndNumberOfSymtom(ClientSymptom clientSymptom)
        {
            int frequncy = clientSymptom.Frequency;
            int difficulty = clientSymptom.Difficulty;
            if ((frequncy + difficulty)>0)
            {
                clientSymptom.TotPsymtom = frequncy + difficulty;
                clientSymptom.Numberofsymptoms = 1;
                return clientSymptom;
            }
            return clientSymptom;
            
        }
    }
}
