using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CaseEdgeTCP : BaseTCP
    {
        public IEnumerable<CaseEdgeJournal> CaseEdgeJournals { get; set; }
    }
}
