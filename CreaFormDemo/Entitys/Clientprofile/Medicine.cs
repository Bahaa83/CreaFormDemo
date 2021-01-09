using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.Clientprofile
{
    [Table(name:"Läkemedel")]
    public class Medicine
    {
        public int ID { get; set; }
        [Column("Läkemedel")]
        public string MedicinName { get; set; }
        [Column("anledning till medicineringen")]
        public string CauseOfMedication { get; set; }
        public IEnumerable<ClientMedicine> clientMedicines { get; set; }

    }
}
