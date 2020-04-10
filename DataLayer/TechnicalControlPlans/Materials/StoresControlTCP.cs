using DataLayer.Journals.Materials;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Materials
{
    public class StoresControlTCP : BaseTCP
    {
        public ObservableCollection<StoresControlJournal> StoresControlJournals { get; set; }
    }
}
