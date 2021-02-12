using CreaFormDemo.Entitys.LifestyleModel.job;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Privat
{
    [Table("Styrka-Brist under Grupp")]
    public class StrengthLackUnderGroup
    {

        [Key]
        public int ID { get; set; }
        [Column("Beskrivning")]
        public string Discription { get; set; }
        [ForeignKey(nameof(strengthLackGroup))]
        [Column("Styrka-Brist Grupp ID")]
        public int StrengthLackGroupID { get; set; }
        public StrengthLackGroup strengthLackGroup { get; set; }
        public IEnumerable<PrivatChoise> privatChoises { get; set; }
        public IEnumerable<JobChoise> jobChoises  { get; set; }
    }
}
