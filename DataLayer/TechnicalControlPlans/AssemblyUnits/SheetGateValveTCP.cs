using System.Collections.Generic;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class SheetGateValveTCP: BaseTCP
    {
        public IEnumerable<SheetGateValveJournal> SheetGateValveJournals { get; set; }
    }
}
