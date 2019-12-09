using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class FrontWallTCP : BaseTCP
    {
        public IEnumerable<FrontWallJournal> FrontWallJournals { get; set; }
    }
}
