using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CompactGateValveCoverTCP : BaseTCP
    {
        public IEnumerable<CompactGateValveCoverJournal> CompactGateValveCoverJournals { get; set; }
    }
}
