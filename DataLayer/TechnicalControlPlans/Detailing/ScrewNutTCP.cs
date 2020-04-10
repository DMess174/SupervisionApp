using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class ScrewNutTCP : BaseTCP
    {
        public ObservableCollection<ScrewNutJournal> ScrewNutJournals { get; set; }
    }
}
