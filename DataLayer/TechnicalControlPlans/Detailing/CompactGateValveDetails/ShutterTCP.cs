using System.Collections.Generic;
using DataLayer.Journals.Detailing;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails
{
    public class ShutterTCP : BaseTCP
    {
        public IEnumerable<ShutterJournal> ShutterJournals{ get; set; }
    }
}
