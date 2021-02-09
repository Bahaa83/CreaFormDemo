
using CreaFormDemo.Entitys.IdentityRolr;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Users
{
    public class User : IdentityUser<int>
    {
        public bool IsBlocked { get; set; }
        public Advisor advisor { get; set; }
        public Client client { get; set; }
        public string UserIdThatCreatedit { get; set; }
        public ICollection<UserRole> userRoles { get; set; }

    }






}

