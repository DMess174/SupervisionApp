using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class SheetGateValveCoverTCP : BaseTCP
    {
        public IEnumerable<SheetGateValveCoverJournal> SheetGateValveCoverJournals { get; set; }
    }
}
