using CreaFormDemo.Entitys.LifestyleModel.job;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Privat
{
    [Table("Styrka-Brist Grupp")]
    public class StrengthLackGroup
    {
        [Key]
        public int ID { get; set; }
        [Column(" Grupp namn")]
        public string GruppName { get; set; }
        public IEnumerable<StrengthLackUnderGroup> strengthLackUnderGroups { get; set; }
        public IEnumerable<PrivatChoise> PrivatChoises { get; set; }
        public IEnumerable<JobChoise> jobChoises { get; set; }

    }
}
