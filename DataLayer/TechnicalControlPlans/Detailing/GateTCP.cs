using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class GateTCP : BaseTCP
    {
        public ObservableCollection<GateJournal> GateJournals { get; set; }
    }
}
