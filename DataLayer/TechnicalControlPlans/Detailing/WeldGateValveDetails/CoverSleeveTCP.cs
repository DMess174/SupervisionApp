using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class CoverSleeveTCP : BaseTCP
    {
        public ObservableCollection<CoverSleeveJournal> CoverSleeveJournals { get; set; }
    }
}
