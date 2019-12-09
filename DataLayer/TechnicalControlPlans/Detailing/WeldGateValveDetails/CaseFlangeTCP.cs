using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CaseFlangeTCP : BaseTCP
    {
        public IEnumerable<CaseFlangeJournal> CaseFlangeJournals { get; set; }
    }
}
