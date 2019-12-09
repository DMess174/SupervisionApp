using System.Collections.Generic;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class CompactGateValveTCP: BaseTCP
    {
        public IEnumerable<CompactGateValveJournal> CompactGateValveJournals { get; set; }
    }
}
