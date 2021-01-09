using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Habits
{
    [Table("Program-Alternativ")]
    public class ProgramsChoise
    {
        [Column("Alternativ ID")]
        public int ChoiseID { get; set; }
        public HabitsChoise choise { get; set; }
        [Column("Program ID")]
        public int ProgramPlanID { get; set; }
        public ProgramPlan program { get; set; }
    }
}
