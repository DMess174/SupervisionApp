using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class ScrewStudTCP : BaseTCP
    {
        public ObservableCollection<ScrewStudJournal> ScrewStudJournals { get; set; }
    }
}
