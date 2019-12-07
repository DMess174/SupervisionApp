using System.Collections.Generic;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class CastGateValveTCP: BaseTCP
    {
        public IEnumerable<CastGateValveJournal> CastGateValveJournals{ get; set; }
    }
}
