using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.Data
{
    public class SeedData
    {
        private readonly CreaFormDBcontext db;

        public SeedData(CreaFormDBcontext db)
        {
            this.db = db;
        }
        public void SeedUserData()
        {
            if (!db.Users.Any())
            {
                byte[] passwordhash, passwordsald;
                CreatePasswordHash("Admin1983", out passwordhash, out passwordsald);
                var newuser = new User()
                {
                    UserName = "Bahaa",
                    //PasswordHash = passwordhash,
                    //PasswordSald = passwordsald,
                    //role = "Admin",
                   
                    
                };
                db.Users.Add(newuser);
                db.SaveChanges();
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
