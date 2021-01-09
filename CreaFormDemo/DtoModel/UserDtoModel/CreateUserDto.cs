using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Användarnamn krävs")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10,MinimumLength =4,ErrorMessage = "Lösenordet måste innehålla minst fyra eller högst tio tecken")]
        public string Password { get; set; }
        public string UserIdThatCreatedit { get; set; }
      

    }
}
