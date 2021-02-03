using CreaFormDemo.Entitys.Clientprofile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.GeneralQuesDtoModel
{
    public class GeneralQuesDto
    {
        public int ID { get; set; }
        
        public string PositionWork { get; set; }
        public int Age { get; set; }
       
        public Gender gender { get; set; }
       
        public double Weight { get; set; }
    
        public int Length { get; set; }
      
        public int Waist { get; set; }
        
        public int Hip { get; set; }
       
        public bool Eliteathletes { get; set; }
      
        public bool Pregnant { get; set; }

        public bool Vegetarian { get; set; }
        public string Diagnoser { get; set; }
        
        public string Supplements { get; set; }
       
        public string OtherInformation { get; set; }
        public int ClientID { get; set; }
      

    }
}
