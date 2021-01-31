using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(name: "Frekvens")]
        public int Frequency { get; set; }
        [Column(name: "Svårighet")]
        public int Difficulty { get; set; }
        [Column(name: "Totalpoäng/symtom")]
        public int TotPsymtom { get; set; }
        [Column(name: "Antal symtom")]
        public int Numberofsymptoms { get; set; }
        public ClientSymptom()
        {
            if (this.Frequency + this.Difficulty > 0)
            {
                this.TotPsymtom = (this.Frequency + this.Difficulty);
                this.Numberofsymptoms = 1;
            }
        }

    }
}
