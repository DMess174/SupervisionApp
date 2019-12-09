using System.Collections.Generic;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails
{
    public class ShutterGuideTCP : BaseTCP
    {
        public IEnumerable<ShutterGuideJournal> ShutterGuideJournals { get; set; }
    }
}
