using CreaFormDemo.Entitys.Clientprofile;
using CreaFormDemo.Entitys.LifestyleModel.Habits;
using CreaFormDemo.Entitys.Symptoms;
using CreaFormDemo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Users
{
    [Table("Klient")]
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [Column(name:"Förnamn")]
        public string Firstname { get; set; }
        [Column(name: "Efternamn")]
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        [Column(name: "Gatuadress")]
        public string Streetaddress { get; set; }
        [Column(name: "Postnummer")]
        public int ZiPCod { get; set; }
        public string Ort { get; set; }
        [Column(name: "Är företagskonto")]
        public bool isCompany { get; set; }

        public int UserID { get; set; }
        public User  user { get; set; }

       
        [Column(name:"Rådgivare ID")]
        public int AdvisorID { get; set; }
        public Advisor advisor { get; set; }
        public GeneralQuestions generalQuestions { get; set; }
        public IEnumerable<Medicine> medicines { get; set; }
        public Well_being well_Being { get; set; }
        public IEnumerable<ClientSymptom> clientSymptoms { get; set; }


    }
}
