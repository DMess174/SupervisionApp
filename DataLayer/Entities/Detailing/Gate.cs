using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class Gate : BaseDetail
    {
        public Gate()
        {
            Name = "Шибер";
        }

        public BaseValve BaseValve { get; set; }

        public IEnumerable<GateJournal> GateJournals { get; set; }
    }
}
