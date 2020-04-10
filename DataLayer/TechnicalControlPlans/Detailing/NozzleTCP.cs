using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class NozzleTCP : BaseTCP
    {
        public ObservableCollection<NozzleJournal> NozzleJournals { get; set; }
    }
}
