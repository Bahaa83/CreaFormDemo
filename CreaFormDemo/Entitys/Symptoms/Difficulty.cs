using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Symptoms
{

    [Table("Svårighet")]
    public class Difficulty
    {
        [Key]
        public int ID { get; set; }

        [Column(name: "Värde")]
        public int Value { get; set; }
     
    }
}
