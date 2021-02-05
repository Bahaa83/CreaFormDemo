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
        public  Client Client { get; set; }
        public string SymtomText { get; set; }
        public int SymtomCategoryID { get; set; }
        public SymptomsCategory symptomsCategory { get; set; }
        [Column(name: "Frekvens")]
        public int Frequency { get; set; }
        [Column(name: "Svårighet")]
        public int Difficulty { get; set; }
        [Column(name: "Totalpoäng/symtom")]
        public int TotPsymtom 
        {
            get { return this.Frequency + this.Difficulty; }
            set { } 
        }
        [Column(name: "Antal symtom")]
        public int Numberofsymptoms
        {
            get { return this.TotPsymtom > 0 ? 1 : 0; }
            set { }
        }
       
        

    }
}
