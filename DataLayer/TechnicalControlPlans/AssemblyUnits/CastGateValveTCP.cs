using System.Collections.ObjectModel;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class CastGateValveTCP: BaseTCP
    {
        public ObservableCollection<CastGateValveJournal> CastGateValveJournals{ get; set; }
    }
}
