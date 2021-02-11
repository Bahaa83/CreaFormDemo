using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel
{
    public class UserDto
    {

        public int ID { get; set; }
        public string UserName { get; set; }
        public bool PasswordIsChanged { get; set; }
        public bool EmailConfirmation { get; set; }
        public string Token { get; set; }
    }
}
