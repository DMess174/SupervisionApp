using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class FrontalSaddleSealingTCP : BaseTCP
    {
        public ObservableCollection<FrontalSaddleSealingJournal> FrontalSaddleSealingJournals { get; set; }
    }
}
