using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Habits
{
    [Table("Vanors Frågor")]
    public class HabitsQuestion
    {
        [Key]
        public int ID { get; set; }
        [Column("Fråge text")]
        public string QuestionText { get; set; }
        public IEnumerable<HabitsChoise> habitschois { get; set; }
        [ForeignKey(nameof(habitsCategory))]
        [Column("kategori ID")]
        public int CategoryID { get; set; }
        public HabitsCategory habitsCategory { get; set; }

    }
}
