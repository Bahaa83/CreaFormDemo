using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Habits
{
    [Table("Plus minus grupp")]
    public class PlusMinusGroup
    {
        [Key]
        public int ID { get; set; }
        [Column(" Grupp namn")]
        public string GruppName { get; set; }
        public IEnumerable<HabitsChoise> habitsChoise { get; set; }
        public IEnumerable<PlusMinusUnderGroup> plusMinusUnderGroups { get; set; }
    }
}
