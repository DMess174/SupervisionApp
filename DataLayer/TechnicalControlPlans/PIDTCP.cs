using DataLayer.Journals;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans
{
    public class PIDTCP : BaseTCP
    {
        public ObservableCollection<PIDJournal> PIDJournals { get; set; }
    }
}
