using CreaFormDemo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Users
{
    [Table("Rådgivare")]
    public class Advisor
    {
        [Key]
        public int ID { get; set; }
        [Column(name:"Förnamn")]
        public string FirstName { get; set; }
        [Column(name:"Efternamn")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Column(name: "Gatuadress")]
        public string Streetaddress { get; set; }
        [Column(name: "Postnummer")]
        public int ZiPCod { get; set; }
        public string Ort { get; set; }

        public IEnumerable<Client>  clients{ get; set; }

        [ForeignKey(nameof(user))]
        public int UserID { get; set; }
        public User user  { get; set; }

    }
}
