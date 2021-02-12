using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Habits
{
    [Table("Vanors alternativ")]
    public class HabitsChoise
    {
        [Key]
        public int ID { get; set; }
        [Column("Alternativ text")]
        public string ChoiseText { get; set; }
        [Column("Poäng")]
        public double Value { get; set; }

        public bool Stress { get; set; }
        [Column("Subopt")]
        public char SuboptimalDegree { get; set; }
        [Column("Nr målsättn vitalit.plan")]
        public int GoalVitalitPlanNum { get; set; }
        [Column("rättelse")]
        public string Amendment { get; set; }


       [ForeignKey(nameof(plusMinusGroup))]
        [Column("Plus-minus grupp")]
        public int plusMinusGroupID { get; set; }
        public PlusMinusGroup plusMinusGroup { get; set; }

        [ForeignKey(nameof(plusMinusUnderGroup))]
        [Column("Undergrupp")]
        public int plusMinusUnderGroupID { get; set; }
        public PlusMinusUnderGroup plusMinusUnderGroup { get; set; }
        [ForeignKey(nameof(question))]
        [Column("Fråga ID")]
        public int QuestionID { get; set; }
        public HabitsQuestion question { get; set; }
        public IEnumerable<ProgramsChoise> programsChoises { get; set; }

    }
}
