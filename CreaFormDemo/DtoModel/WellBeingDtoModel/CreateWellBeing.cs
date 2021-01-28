using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.DtoModel.WellBeingDtoModel
{
    public class CreateWellBeing
    {
       [Range(1,11,ErrorMessage = "Skala 1-10, där 10 är högsta välbefinnande och 1 sämsta")]
        public int Total { get; set; }
        [Range(1, 11, ErrorMessage = "Skala 1-10, där 10 är högsta välbefinnande och 1 sämsta")]
        public int Physically { get; set; }
        [Range(1, 11, ErrorMessage = "Skala 1-10, där 10 är högsta välbefinnande och 1 sämsta")]
        public int MentallyCognitively { get; set; }
        [Range(1, 11, ErrorMessage = "Skala 1-10, där 10 är högsta välbefinnande och 1 sämsta")]
        public int Emotionally { get; set; }
       

    }
}
