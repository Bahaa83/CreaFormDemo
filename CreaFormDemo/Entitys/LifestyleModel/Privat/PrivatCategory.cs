using CreaFormDemo.Entitys.LifestyleModel.Habits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Privat
{
    [Table("Privat kategori")]
    public class PrivatCategory
    {
        [Key]
        public int ID { get; set; }
        [Column("Kategori namn")]
        public string CategoryName { get; set; }
        public IEnumerable<PrivatQuestion>  privatQuestions { get; set; }
        [ForeignKey(nameof(lifestyleArea))]
        [Column("Livs stil område")]
        public int LifestylAreaID { get; set; }
        public  LifestyleArea lifestyleArea { get; set; }

    }
}
