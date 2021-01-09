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
        Task<User> Rigester(int UserID,string name, string password,string role);
        Task<User> Login(string name, string password);
       
    }
}
