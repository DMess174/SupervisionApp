using System.Collections.Generic;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class ReverseShutterCaseTCP : BaseTCP
    {
        public IEnumerable<ReverseShutterCaseJournal> ReverseShutterCaseJournals { get; set; }
    }
}
