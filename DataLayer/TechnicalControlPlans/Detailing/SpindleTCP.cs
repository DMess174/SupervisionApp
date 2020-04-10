using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class SpindleTCP : BaseTCP
    {
        public ObservableCollection<SpindleJournal> SpindleJournals { get; set; }
    }
}
