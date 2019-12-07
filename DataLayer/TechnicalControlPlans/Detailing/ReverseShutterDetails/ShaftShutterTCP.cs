using System.Collections.Generic;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class ShaftShutterTCP : BaseTCP
    {
        public IEnumerable<ShaftShutterJournal> ShaftShutterJournals { get; set; }
    }
}
