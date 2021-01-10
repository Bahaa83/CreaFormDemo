using AutoMapper;
using CreaFormDemo.DtoModel;
using CreaFormDemo.DtoModel.UserDtoModel;
using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;
        public SeedData(CreaFormDBcontext db,IMapper mapper , UserManager<User> userManeger)
        {
            this.db = db;
            this.userManeger = userManeger;
            this.mapper = mapper;
        }
        public  void SeedUserData()
        {
            if (!userManeger.Users.Any())
            {
                var newuser = new UserDto()
                {
                    UserName = "Bahaa",
                    
                };
                var user = mapper.Map<User>(newuser);

                userManeger.CreateAsync(user, "bahaa1983").Wait();
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
