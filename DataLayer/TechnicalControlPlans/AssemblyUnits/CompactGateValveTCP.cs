using System.Collections.ObjectModel;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class CompactGateValveTCP: BaseTCP
    {
        public ObservableCollection<CompactGateValveJournal> CompactGateValveJournals { get; set; }
    }
}
