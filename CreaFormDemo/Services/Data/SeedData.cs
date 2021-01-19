using AutoMapper;
using CreaFormDemo.DtoModel;
using CreaFormDemo.DtoModel.UserDtoModel;
using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.LifestyleModel.Habits;
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

        public SeedData(CreaFormDBcontext db)
        {
            this.db = db;
        }
        public void SeedUserData()
        {
            string [] lifestyleAreas={ "Vanor","Arbete","Privat"};
            string[] VanorKategori = { "Vätske-intag", "Kost-näring", "Måltids-vanor", "Stimu-lantia", "Sömn", "Stress-återhämtning", "Fysisk aktivitet", "Droger" };
            if (!db.users.Any())
            {
                byte[] passwordhash, passwordsald;
                CreatePasswordHash("Admin1983", out passwordhash, out passwordsald);
                var newuser = new User()
                {
                    UserName = "Bahaa",
                    PasswordHash = passwordhash,
                    PasswordSald = passwordsald,
                    role = "Admin"
                };
                db.users.Add(newuser);
                db.SaveChanges();
            }
            if(!db.lifestyleAreas.Any())
            {
                for (int i = 0; i < lifestyleAreas.Length; i++)
                {
                    var lifestyle = new LifestyleArea()
                    {
                        Name = lifestyleAreas[i]

                    };
                    db.lifestyleAreas.Add(lifestyle);
                }
                db.SaveChanges();
                //var lifestyleArea1 = new LifestyleArea()
                //{
                //    Name="Vanor"
                //};
                //var lifestyleArea2 = new LifestyleArea()
                //{
                //    Name = "Arbete"
                //};
                //var lifestyleArea3 = new LifestyleArea()
                //{
                //    Name = "Privat"
                //};
                //db.lifestyleAreas.Add(lifestyleArea1);
                //db.lifestyleAreas.Add(lifestyleArea2);
                //db.lifestyleAreas.Add(lifestyleArea3);
                //db.SaveChanges();
            }
            if(!db.habitsCategories.Any())
            {
                for (int i = 0; i < VanorKategori.Length; i++)
                {
                    var categoryname = new HabitsCategory()
                    {
                        CategoryName= VanorKategori[i],
                        LifestyleAreaID=1
                        
                    };
                    db.habitsCategories.Add(categoryname);
                    db.SaveChanges();
                }
                
            }
        }

        //private void SaveChanges()
        //{
        //    db.SaveChanges();
        //}
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
