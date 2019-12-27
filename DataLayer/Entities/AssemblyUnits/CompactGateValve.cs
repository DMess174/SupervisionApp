using System.Collections.Generic;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class CompactGateValve : BaseWeldValve
    {
        public CompactGateValve()
        {
            Name = "ЗШК";
        }

        public IEnumerable<CompactGateValveJournal> CompactGateValveJournals { get; set; }
    }
}
