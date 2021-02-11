using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Helpers
{
    public class Record
    {
        public string ID { get; set; }
        public Record()
        {
           this.ID = Guid.NewGuid().ToString();
        }
    }
}
