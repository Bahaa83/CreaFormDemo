using CreaFormDemo.DtoModel.SymtomDtoModel;
using CreaFormDemo.Entitys.Symptoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.IRepository
{
    public interface ISymtomRepo
    {
        Task<int> GetSymtomCategoryID(string symtomtext);
        Task<bool> AddSymtomAnswer(ClientSymptom clientSymptom);
       
  
    }
}
