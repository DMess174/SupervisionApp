using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class SteelSleeveShutterTCP : BaseTCP
    {
        public ObservableCollection<SteelSleeveShutterJournal> SteelSleeveShutterJournals { get; set; }
    }
}
