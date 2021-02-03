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
        Task<GeneralQuestions> updateGeneralQuestions(GeneralQuestions model);
        Task<Well_being> GetWellbeingByUserid(int Userid);
        Task<Medicine> GetMedicineByUserID(int Userid);
        Task<SymptomsCategory> GetSymptomsQuesbycategory(int orderby);
        Task<IEnumerable<Difficulty>> GetDifficultyValue();
        Task<IEnumerable<Frequency>> GetFrequencyValue();
        Task<Well_being> FillInWellBeing(Well_being model);
        Task<int> GetClientidbyGeneralidID(int id);

        Task<bool> Save();
    }
}
