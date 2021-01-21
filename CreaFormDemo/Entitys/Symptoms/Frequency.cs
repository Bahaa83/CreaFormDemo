using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Symptoms
{
    [Table(name: "Frekvens")]
    public class Frequency
    {
        public int ID { get; set; }
        [Column(name:"Frekvens Text")]
        public string frequencyText { get; set; }
        [Column(name: "Värde")]
        public int Value { get; set; }


    }
}
