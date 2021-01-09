using CreaFormDemo.Entitys.LifestyleModel.Privat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.job
{
    [Table("Arbete Svaror")]
    public class JobChoise
    {
        
        [Key]
        public int ID { get; set; }
        [Column(" Alternativ text")]
        public string ChoiseText { get; set; }
        [Column("Poäng")]
        public double Value { get; set; }

        public bool Stress { get; set; }

        [ForeignKey(nameof(strengthLackGroup))]
        [Column("Styrka/Brist ID")]
        public int StrengthLackGroupID { get; set; }
        public StrengthLackGroup strengthLackGroup { get; set; }

        [ForeignKey(nameof(strengthLackUnderGroup))]
        [Column("Styrka/Brist under grupp ID")]
        public int StrengthLackUnderGroupID { get; set; }
        public StrengthLackUnderGroup strengthLackUnderGroup { get; set; }

        [ForeignKey(nameof(jobQuestion))]
        [Column("Fråge ID")]
        public int QuestionID { get; set; }
        public JobQuestion jobQuestion { get; set; }

    }
}
