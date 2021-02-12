using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Privat
{
    [Table("Privat Frågor")]
    public class PrivatQuestion
    {

        [Key]
        public int ID { get; set; }
        [Column("Fråge text")]
        public string QuestionText { get; set; }
        public IEnumerable<PrivatChoise> privatchoises { get; set; }
        [ForeignKey(nameof(privatCategory))]
        [Column("kategori ID")]
        public int CategoryID { get; set; }
        public PrivatCategory privatCategory { get; set; }
    }
}
