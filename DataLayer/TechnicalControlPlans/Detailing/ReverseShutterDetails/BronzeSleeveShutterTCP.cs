using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class BronzeSleeveShutterTCP : BaseTCP
    {
        public ObservableCollection<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
    }
}
