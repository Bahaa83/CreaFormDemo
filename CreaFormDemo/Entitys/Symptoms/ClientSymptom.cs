using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Symptoms
{
    public class ClientSymptom
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public string SymtomText { get; set; }
        public int SymtomCategoryID { get; set; }
        public int Frequency { get; set; }
        public int Difficulty { get; set; }

    }
}
