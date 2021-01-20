using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.MedicineDtoModel
{
    public class CreateMedicineDto
    {
        [Required(ErrorMessage = "Läkemedelsnamn krävs")]

        public string MedicinName { get; set; }

        public string CauseOfMedication { get; set; }
    }
}
