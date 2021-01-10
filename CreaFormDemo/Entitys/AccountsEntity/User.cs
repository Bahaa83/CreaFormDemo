
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Users
{
    public class User:IdentityUser<int>
    {
        //[Key]
        //public int ID { get; set; }
        //public string UserName { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSald { get; set; }
        //public string role { get; set; }
        public bool IsBlocked { get; set; }
        [NotMapped]
        //public string Token { get; set; }
        public Advisor  advisor { get; set; }
        public Client  client { get; set; }
        public string UserIdThatCreatedit { get; set; }
        public User()
        {
            IsBlocked = false;
        }
    
       
    


    }
}
