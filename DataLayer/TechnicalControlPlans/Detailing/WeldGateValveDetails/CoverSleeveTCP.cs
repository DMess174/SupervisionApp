using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CoverSleeveTCP : BaseTCP
    {
        public IEnumerable<CoverSleeveJournal> CoverSleeveJournals { get; set; }
    }
}
