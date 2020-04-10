using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class ShaftShutterTCP : BaseTCP
    {
        public ObservableCollection<ShaftShutterJournal> ShaftShutterJournals { get; set; }
    }
}
