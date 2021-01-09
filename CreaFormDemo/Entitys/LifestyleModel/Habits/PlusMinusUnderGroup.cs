using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Habits
{
    [Table("Plus minus under grupp")]
    public class PlusMinusUnderGroup
    {

        [Key]
        public int ID { get; set; }
        [Column(" under grupp")]
        public string Discription { get; set; }
        public IEnumerable<HabitsChoise> habitsChoises { get; set; }

        [ForeignKey(nameof(plusMinusGroup))]
        [Column(" Plus minus grupp ID")]
        public int PlusMinusGroupID { get; set; }
        public PlusMinusGroup  plusMinusGroup { get; set; }
    }
}
