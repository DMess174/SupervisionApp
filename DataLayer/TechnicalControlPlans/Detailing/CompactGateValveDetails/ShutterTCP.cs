using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails
{
    public class ShutterTCP : BaseTCP
    {
        public ObservableCollection<ShutterJournal> ShutterJournals{ get; set; }
    }
}
