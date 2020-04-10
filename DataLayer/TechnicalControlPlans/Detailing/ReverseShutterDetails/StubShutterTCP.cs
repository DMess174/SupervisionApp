using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class StubShutterTCP : BaseTCP
    {
        public ObservableCollection<StubShutterJournal> StubShutterJournals{ get; set; }
    }
}
