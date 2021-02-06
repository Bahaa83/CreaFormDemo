using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Symptoms
{
    public class SymtomOverview
    {

        //public int ID { get; set; }
        //public int ClientID { get; set; }
            public string SymtomCategory { get; set; }
            public int TotalFrequency { get; set; }
         
            public int TotalDifficulty { get; set; }
         
            public int TotPsymtom
            {
                get { return this.TotalFrequency + this.TotalDifficulty; }
                set { }
            }
          
            public int totalNumberofsymptoms { get; set; }

        
    }
}
