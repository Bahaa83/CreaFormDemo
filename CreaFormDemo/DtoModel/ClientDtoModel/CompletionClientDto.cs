using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.ClientDtoModel
{
    public class CompletionClientDto
    {
        [Required(ErrorMessage ="Förnamn är obligatorisk")]
        [StringLength(8,MinimumLength =4,ErrorMessage = "Förnamn måste innehålla minst fyra eller högst 8 tecken")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Efternamn är obligatorisk")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Efternamn måste innehålla minst fyra eller högst 10 tecken")]
        public string Lastname { get; set; }

        [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
        [Required(ErrorMessage = "Eposten är obligatorisk")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Ange en giltig e-postadress")]
        public string Email { get; set; }

        [Required]
        [Compare("Email", ErrorMessage = "Eposten stämmer inte överens")]

        public string ConfirmEmail { get; set; }
        [Required(ErrorMessage ="Mobilnummer är obligatorisk")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Gatuadress är obligatorisk")]
        public string Streetaddress { get; set; }
        [Required(ErrorMessage = "Postnummer är obligatorisk")]
        public int ZiPCod { get; set; }
        [Required(ErrorMessage = "Ort är obligatorisk")]
        
        public string Ort { get; set; }
        [Required]
        public bool isCompany { get; set; }

        public int UserID { get; set; }
        public int AdvisorID { get; set; }
    }
}
