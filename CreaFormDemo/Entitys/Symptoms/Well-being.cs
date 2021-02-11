using CreaFormDemo.Entitys.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Symptoms
{
    [Table(name: "Välbefinnande - uppskattning")]
    public class Well_being
    {
        public int ID { get; set; }
        [Column(name:"Totalt")]
        public int Total { get; set; }
        [Column(name: "Fysiskt")]
        public int Physically { get; set; }
        [Column(name: "Mentalt/kognitivt")]
        public int MentallyCognitively { get; set; }
        [Column(name: "Känslomässigt")]
        public int Emotionally { get; set; }
        public string ClientID { get; set; }
        public Client client { get; set; }


    }
}
