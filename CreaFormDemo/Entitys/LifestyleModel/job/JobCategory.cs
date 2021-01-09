using CreaFormDemo.Entitys.LifestyleModel.Habits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.job
{
    [Table("Arbete Kategori")]
    public class JobCategory
    {
        [Key]
        public int ID { get; set; }
        [Column("Kategori Namn")]
        public string CategoryName { get; set; }
        public IEnumerable<JobQuestion>  jobQuestions { get; set; }
        [ForeignKey(nameof(lifestyleArea))]
        [Column("Livs stil område")]
        public int LifestylAreaID { get; set; }
        public LifestyleArea lifestyleArea { get; set; }
    }
}

