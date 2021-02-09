using CreaFormDemo.Entitys.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.IdentityRolr
{
    public class Role: IdentityRole<int>
    {
        public User user { get; set; }
    }
}
