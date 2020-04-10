using System.Collections.ObjectModel;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class ReverseShutterTCP: BaseTCP
    {
        public ObservableCollection<ReverseShutterJournal> ReverseShutterJournals { get; set; }
    }
}
