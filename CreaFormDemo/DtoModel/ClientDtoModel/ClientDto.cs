﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.ClientDtoModel
{
    public class ClientDto
    {
        public int ID { get; set; }
      
        public string Firstname { get; set; }
       
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
    
        public bool isCompany { get; set; }

    }
}
