using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CompactGateValveCoverTCP : BaseTCP
    {
        public ObservableCollection<CompactGateValveCoverJournal> CompactGateValveCoverJournals { get; set; }
    }
}
