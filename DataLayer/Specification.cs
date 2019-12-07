using System.Collections.Generic;

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
