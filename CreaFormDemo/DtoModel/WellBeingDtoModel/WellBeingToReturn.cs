using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.WellBeingDtoModel
{
    public class WellBeingToReturn
    {
        public int ID { get; set; }
        
        public int Total { get; set; }
    
        public int Physically { get; set; }
       
        public int MentallyCognitively { get; set; }
      
        public int Emotionally { get; set; }
        public int ClientID { get; set; }
        

    }
}
