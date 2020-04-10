using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class SlamShutterTCP : BaseTCP
    {
        public ObservableCollection<SlamShutterJournal> SlamShutterJournals { get; set; }
    }
}
