using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CoverFlangeTCP : BaseTCP
    {
        public IEnumerable<CoverFlangeJournal> CoverFlangeJournals { get; set; }
    }
}
