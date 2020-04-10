using System.Collections.ObjectModel;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class SheetGateValveTCP: BaseTCP
    {
        public ObservableCollection<SheetGateValveJournal> SheetGateValveJournals { get; set; }
    }
}
