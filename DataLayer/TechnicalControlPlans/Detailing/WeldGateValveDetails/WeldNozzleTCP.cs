using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class WeldNozzleTCP : BaseTCP
    {
        public IEnumerable<WeldNozzleJournal> WeldNozzleJournals { get; set; }
    }
}
