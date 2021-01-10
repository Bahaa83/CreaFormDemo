using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.Data
{
    public class SeedData
    {
        private readonly CreaFormDBcontext db;
        private readonly UserManager<User> userManeger;
        public SeedData(CreaFormDBcontext db, UserManager<User> userManeger)
        {
            this.db = db;
            this.userManeger = userManeger;
        }
        public void SeedUserData()
        {
            if (!userManeger.Users.Any())
            {
                var newuser = new User()
                {
                    UserName = "Bahaa",
                };
                userManeger.CreateAsync(newuser, "bahaa1983").Wait();
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordsald)
        {
           using(var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordsald = hmac.Key;
                passwordhash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
