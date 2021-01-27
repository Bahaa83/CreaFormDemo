﻿using CreaFormDemo.Entitys.Clientprofile;
using CreaFormDemo.Entitys.Symptoms;
using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.IRepository
{
  public  interface IClientRepository
    {
        Task<Client> CompletionClientProfile(Client client);
        Task<User> GetUserByID(int ID);
        Task<Client> GetClientByUserID(int ID);
        Task<GeneralQuestions> FillInTheGeneralQuestions(GeneralQuestions clientProfile);
        Task<Medicine> FillInTheMedicineInformations(Medicine medicine);
        Task<GeneralQuestions> GetGeneralQuestionsByUserID(int userid);
        Task<IEnumerable< SymptomQuestions>> GetSymptomsQuesbycategory(int orderby);

        Task<bool> Save();
    }
}
