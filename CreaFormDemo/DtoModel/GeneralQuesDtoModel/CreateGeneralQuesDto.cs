using CreaFormDemo.Entitys.Clientprofile;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.GeneralQuesDtoModel
{
    public class CreateGeneralQuesDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Arbete är obligatorisk")]
        public string PositionWork { get; set; }
        [Required(ErrorMessage = "Födelsedagen är obligatorisk")]
        [DataType(DataType.Date)]
        public DateTime DofB { get; set; }
        [Required(ErrorMessage = "Kön är obligatorisk")]
        public Gender gender { get; set; }
        [Required(ErrorMessage = "Vikt är obligatorisk")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Längd är obligatorisk")]
        public int Length { get; set; }
        [Required(ErrorMessage = "Midja är obligatorisk")]
        public int Waist { get; set; }
        [Required(ErrorMessage = "Höft är obligatorisk")]
        public int Hip { get; set; }
      
        public bool Eliteathletes { get; set; }
     
        public bool Pregnant { get; set; }

        public bool Vegetarian { get; set; }
        public string Diagnoser { get; set; }
      
        public string Supplements { get; set; }
    
        public string OtherInformation { get; set; }
      

    }
}
