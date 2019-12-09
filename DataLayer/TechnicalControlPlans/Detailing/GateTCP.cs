using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class GateTCP : BaseTCP
    {
        public IEnumerable<GateJournal> GateJournals { get; set; }
    }
}
