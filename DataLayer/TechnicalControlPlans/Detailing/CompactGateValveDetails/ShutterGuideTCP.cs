using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails
{
    public class ShutterGuideTCP : BaseTCP
    {
        public ObservableCollection<ShutterGuideJournal> ShutterGuideJournals { get; set; }
    }
}
