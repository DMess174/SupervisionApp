using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CaseFlangeTCP : BaseTCP
    {
        public ObservableCollection<CaseFlangeJournal> CaseFlangeJournals { get; set; }
    }
}
