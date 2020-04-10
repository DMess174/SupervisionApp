using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails
{
    public class ShutterDiskTCP : BaseTCP
    {
        public ObservableCollection<ShutterDiskJournal> ShutterDiskJournals{ get; set; }
    }
}
