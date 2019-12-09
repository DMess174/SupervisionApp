using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class SideWallTCP : BaseTCP
    {
        public IEnumerable<SideWallJournal> SideWallJournals { get; set; }
    }
}
