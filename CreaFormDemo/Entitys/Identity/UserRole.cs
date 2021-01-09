using CreaFormDemo.Entitys.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Identity
{
    public class UserRole:IdentityUserRole<int>
    {
        public User user { get; set; }
        public Role role { get; set; }
    }
}
