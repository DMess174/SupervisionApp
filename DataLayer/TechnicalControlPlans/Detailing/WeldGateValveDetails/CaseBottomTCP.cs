using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CaseBottomTCP : BaseTCP
    {
        public IEnumerable<CaseBottomJournal> CaseBottomJournals { get; set; }
    }
}
