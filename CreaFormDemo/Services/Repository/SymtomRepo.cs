using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Symptoms;
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
            var result= await db.clientSymptoms.AddAsync(clientSymptom);
            if (result == null) return false;
            return true;
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
    }
}
