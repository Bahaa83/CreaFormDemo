using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Clientprofile
{
    [Table(name: "Allmänt")]
    public class GeneralQuestions
    {
        public int ID { get; set; }
        [Column(name: "Befattning/arbete")]
        public string PositionWork { get; set; }
        [Column(name: "Föddelsedatum")]
        public DateTime DofB { get; set; }
        [Column(name: "Ålder")]
        public int  Age
        {
            get { 
                var today=DateTime.Today;
                return Convert.ToInt32( today.Year - this.DofB.Year);
            }
            set { }
        }
        [Column(name: "Kön")]
        public Gender gender { get; set; }
        [Column("Vikt/kg")]
        public double Weight { get; set; }
        [Column("Längd")]
        public int Length { get; set; }
        [Column("Midjemått")]
        public int Waist { get; set; }
        [Column("Höftmått")]
        public int Hip  { get; set; }
        [Column("Elitidrottare ")]
        public bool Eliteathletes { get; set; }
        [Column("Gravid ")]
        public bool Pregnant { get; set; }
       
        public bool Vegetarian { get; set; }
        public string Diagnoser { get; set; }
        [Column("Kosttillskott ")]
        public string Supplements { get; set; }
        [Column("Övriga upplysningar ")]
        public string OtherInformation { get; set; }
        public int ClientID { get; set; }
        public Client client  { get; set; }
       

    }
}
