using System.Collections.Generic;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class StubShutterTCP : BaseTCP
    {
        public IEnumerable<StubShutterJournal> StubShutterJournals{ get; set; }
    }
}
