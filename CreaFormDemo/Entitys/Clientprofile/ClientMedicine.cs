using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Clientprofile
{
    public class ClientMedicine
    {
        public int ClientID { get; set; }
        public Client  client { get; set; }

        public int MedicineID { get; set; }
        public Medicine  medicine { get; set; }
    }
}
