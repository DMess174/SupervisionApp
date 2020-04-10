using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CaseEdgeTCP : BaseTCP
    {
        public ObservableCollection<CaseEdgeJournal> CaseEdgeJournals { get; set; }
    }
}
