using System.Collections.Generic;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class CoatingTCP: BaseTCP
    {
        public IEnumerable<CoatingJournal> CoatingJournals { get; set; }
    }
}
