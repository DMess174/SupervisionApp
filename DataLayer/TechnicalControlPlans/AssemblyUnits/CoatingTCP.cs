using System.Collections.ObjectModel;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class CoatingTCP: BaseTCP
    {
        public ObservableCollection<CoatingJournal> CoatingJournals { get; set; }
    }
}
