using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class SpringTCP : BaseTCP
    {
        public ObservableCollection<SpringJournal> SpringJournals { get; set; }
    }
}
