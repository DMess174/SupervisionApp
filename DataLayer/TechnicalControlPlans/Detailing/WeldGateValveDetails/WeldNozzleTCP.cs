using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class WeldNozzleTCP : BaseTCP
    {
        public ObservableCollection<WeldNozzleJournal> WeldNozzleJournals { get; set; }
    }
}
