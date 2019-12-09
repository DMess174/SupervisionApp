using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CompactGateValveCaseTCP : BaseTCP
    {
        public IEnumerable<CompactGateValveCaseJournal> CompactGateValveCaseJournals { get; set; }
    }
}
