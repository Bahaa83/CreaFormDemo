using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Symptoms
{
    public class ClientSymtomOverview
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int SymtomCategoryID { get; set; }
        public string SymtomText { get; set; }
        [Column(name: "Frekvens")]
        public int Frequency { get; set; }
        [Column(name: "Svårighet")]
        public int Difficulty { get; set; }
        [Column(name: "Totalpoäng/symtom")]
        public int TotPsymtom { get; set; }
        [Column(name: "Antal symtom")]
        public int Numberofsymptoms { get; set; }
       
    }
}
