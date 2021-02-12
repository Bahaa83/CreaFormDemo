using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Repository
{
  public  interface IAuthRepository
    {
        Task<bool> UserExists(string name);
        Task<UserModel> Rigester(string UserID,string name, string password,string role);
        Task<UserModel> Login(string name, string password);
        Task<UserModel> GetUserByID(string id);
        Task<bool> ChangePassword(UserModel user, string currentpassword, string newpassword);
       
    }
}
