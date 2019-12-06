using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Specification : BasePropertyChanged
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Program { get; set; }
        public string Consignee { get; set; }
        public string Facility { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<PID> PIDs { get; set; }
    }
}
