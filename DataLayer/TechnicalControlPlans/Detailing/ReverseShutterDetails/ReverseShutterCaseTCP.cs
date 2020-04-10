using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails
{
    public class ReverseShutterCaseTCP : BaseTCP
    {
        public ObservableCollection<ReverseShutterCaseJournal> ReverseShutterCaseJournals { get; set; }
    }
}
