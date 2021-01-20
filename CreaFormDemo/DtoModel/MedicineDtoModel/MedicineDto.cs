using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.MedicineDtoModel
{
    public class MedicineDto
    {
        public int ID { get; set; }
       
        public string MedicinName { get; set; }
       
        public string CauseOfMedication { get; set; }
        public int clientID { get; set; }
       

    }
}
