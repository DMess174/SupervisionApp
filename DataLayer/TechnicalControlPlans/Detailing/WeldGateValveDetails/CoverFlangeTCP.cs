using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CoverFlangeTCP : BaseTCP
    {
        public ObservableCollection<CoverFlangeJournal> CoverFlangeJournals { get; set; }
    }
}
