using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.job
{
    [Table("Arbete frågor")]
    public class JobQuestion
    {
        [Key]
        public int ID { get; set; }
        [Column("Fråge text")]
        public string QuestionText { get; set; }
        public IEnumerable<JobChoise> jobchoises { get; set; }
       [ForeignKey(nameof(JobCategory))]
        [Column("Kategori ID")]
        public int CategoryID { get; set; }
        public JobCategory JobCategory { get; set; }
    }
}
