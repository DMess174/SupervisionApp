using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CompactGateValveCaseTCP : BaseTCP
    {
        public ObservableCollection<CompactGateValveCaseJournal> CompactGateValveCaseJournals { get; set; }
    }
}
