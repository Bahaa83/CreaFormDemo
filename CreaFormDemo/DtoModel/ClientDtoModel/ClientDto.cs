using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.ClientDtoModel
{
    public class ClientDto
    {
       
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Streetaddress { get; set; }
        public int ZiPCod { get; set; }
        public string Ort { get; set; }
        public bool isCompany { get; set; }
        public string UserID { get; set; }
        public string AdvisorID { get; set; }
    }
}
