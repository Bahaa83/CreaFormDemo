using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Symptoms
{
    [Table(name: "Symtom kategori")]
    public class SymptomsCategory
    {
        [Key]
        public int ID { get; set; }
        [Column(name: "Kategoris namn")]
        public string Name { get; set; }
        public int OrderBy { get; set; }
        public IEnumerable<SymptomQuestions> symptomQuestions { get; set; }

    }
}
