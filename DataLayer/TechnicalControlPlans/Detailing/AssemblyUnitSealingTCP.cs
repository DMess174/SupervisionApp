using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class AssemblyUnitSealingTCP : BaseTCP
    {
        public IEnumerable<AssemblyUnitSealingJournal> AssemblyUnitSealingJournals { get; set; }
    }
}
