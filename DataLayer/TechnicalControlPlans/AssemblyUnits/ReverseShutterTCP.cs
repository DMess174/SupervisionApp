using System.Collections.Generic;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class ReverseShutterTCP: BaseTCP
    {
        public IEnumerable<ReverseShutterJournal> ReverseShutterJournals { get; set; }
    }
}
