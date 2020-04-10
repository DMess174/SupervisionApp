using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class CoverSealingRingTCP : BaseTCP
    {
        public ObservableCollection<CoverSealingRingJournal> CoverSealingRingJournals { get; set; }
    }
}
