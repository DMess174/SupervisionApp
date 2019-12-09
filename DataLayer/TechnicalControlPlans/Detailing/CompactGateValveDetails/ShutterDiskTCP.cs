using System.Collections.Generic;
using DataLayer.Journals.Detailing;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails
{
    public class ShutterDiskTCP : BaseTCP
    {
        public IEnumerable<ShutterDiskJournal> ShutterDiskJournals{ get; set; }
    }
}
