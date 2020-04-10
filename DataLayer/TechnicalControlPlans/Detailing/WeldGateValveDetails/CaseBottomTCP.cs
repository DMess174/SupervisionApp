using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CaseBottomTCP : BaseTCP
    {
        public ObservableCollection<CaseBottomJournal> CaseBottomJournals { get; set; }
    }
}
