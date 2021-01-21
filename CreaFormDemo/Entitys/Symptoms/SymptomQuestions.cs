using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Symptoms
{
    [Table(name: "Symtom Frågor ")]
    public class SymptomQuestions
    {
        public int ID { get; set; }
        [Column(name:"Symtom text")]
        public string FråganText { get; set; }
        [Column(name: "Beskrivning")]
        public string Description { get; set; }
        public int SymptomsCategoryID { get; set; }
        public SymptomsCategory symptomsCategory { get; set; }
        //public IEnumerable<Frequency> frequencies  { get; set; }
        //public IEnumerable<Difficulty> difficultie { get; set; }

    }
}
