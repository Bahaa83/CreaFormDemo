using CreaFormDemo.Entitys.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Identity
{
    public class Role:IdentityRole<int>
    {
        public IEnumerable<UserRole> userRoles { get; set; }
    }
}
