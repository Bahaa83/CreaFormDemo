using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel
{
    public class CreatedUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
       
        public string Password { get; set; }
        public string UserIdThatCreatedit { get; set; }
      

    }
}
