using DataLayer.Journals.Periodical;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class NDTControlTCP : BaseTCP
    {
        public ObservableCollection<NDTControlJournal> NDTControlJournals { get; set; }
    }
}
