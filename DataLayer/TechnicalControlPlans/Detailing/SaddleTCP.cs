using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class SaddleTCP : BaseTCP
    {
        public ObservableCollection<SaddleJournal> SaddleJournals { get; set; }
    }
}
