using System.Collections.Generic;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class SteelSleeveShutterTCP : BaseTCP
    {
        public IEnumerable<SteelSleeveShutterJournal> SteelSleeveShutterJournals { get; set; }
    }
}
