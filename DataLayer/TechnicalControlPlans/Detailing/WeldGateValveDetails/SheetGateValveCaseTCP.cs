using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class SheetGateValveCaseTCP : BaseTCP
    {
        public IEnumerable<SheetGateValveCaseJournal> SheetGateValveCaseJournals { get; set; }
    }
}
