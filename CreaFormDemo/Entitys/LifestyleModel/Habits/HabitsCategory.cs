using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Habits
{
    [Table("Vanors kategori")]
    public class HabitsCategory
    {
        [Key]
        public int ID { get; set; }
        [Column(name: "kategoris Namn")]
        public string CategoryName { get; set; }
        [Column(name:"Vanors Frågor")]
        public IEnumerable<HabitsQuestion>  habitsQuestions{ get; set; }

        [ForeignKey(nameof(lifestyleArea))]
        [Column(name: "Livs stil område")]
        public int LifestyleAreaID { get; set; }
        public LifestyleArea lifestyleArea { get; set; }
    }
}
