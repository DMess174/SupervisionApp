using System.Collections.Generic;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class SlamShutterTCP : BaseTCP
    {
        public IEnumerable<SlamShutterJournal> SlamShutterJournals { get; set; }
    }
}
