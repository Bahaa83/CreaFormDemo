using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.SymtomDtoModel
{
    public class SymtomAnswer
    {
        public int ClientID { get; set; }
        public string SymtomText { get; set; }
        public int Frequency { get; set; }
        public int Difficulty { get; set; }

    }
}
