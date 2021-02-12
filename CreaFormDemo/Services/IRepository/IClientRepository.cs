using CreaFormDemo.Entitys.Clientprofile;
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
        Task<UserModel> GetUserByID(string ID);
        Task<Client> GetClientByUserID(string ID);
        Task<GeneralQuestions> FillInTheGeneralQuestions(GeneralQuestions clientProfile);
        Task<Medicine> FillInTheMedicineInformations(Medicine medicine);
        Task<GeneralQuestions> GetGeneralQuestionsbyUserid(string id);
        Task<Well_being> GetWellbeingByUserid(string Userid);
        Task<Medicine> GetMedicineByUserID(string Userid);
        Task<SymptomsCategory> GetSymptomsQuesbycategory(int orderby);
        Task<IEnumerable<Difficulty>> GetDifficultyValue();
        Task<IEnumerable<Frequency>> GetFrequencyValue();
        Task<Well_being> FillInWellBeing(Well_being model);
      

        Task<bool> Save();
    }
}
