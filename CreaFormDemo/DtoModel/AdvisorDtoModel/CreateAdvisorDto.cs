﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel
{
    public class CreateAdvisorDto
    {

        [Required(ErrorMessage = "Förstnamn är obligatorisk")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Efternamn är obligatorisk")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
        [Required(ErrorMessage = "Eposten är obligatorisk")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Ange en giltig e-postadress")]
        public string Email { get; set; }

        [Required]
        [Compare("Email", ErrorMessage = "Eposten stämmer inte överens")]

        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = " Phone är obligatorisk")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Gatuadress är obligatorisk")]
        public string Streetaddress { get; set; }
        [Required(ErrorMessage = "Postnummer är obligatorisk")]
        public int ZiPCod { get; set; }
        [Required(ErrorMessage = "Ort är obligatorisk")]
        public string  Ort { get; set; }
    }
}
