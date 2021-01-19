using CreaFormDemo.Entitys.LifestyleModel.job;
using CreaFormDemo.Entitys.LifestyleModel.Privat;
using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Habits
{
    [Table("Livs stil område")]
    public class LifestyleArea
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public HabitsCategory habitscategory { get; set; }
        public PrivatCategory privatcategory { get; set; }
        public JobCategory jobcategory { get; set; }
     
    }
}
