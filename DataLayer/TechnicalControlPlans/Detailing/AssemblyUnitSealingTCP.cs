using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class AssemblyUnitSealingTCP : BaseTCP
    {
        public ObservableCollection<AssemblyUnitSealingJournal> AssemblyUnitSealingJournals { get; set; }
    }
}
