using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class BallValveTCP : BaseTCP
    {
        public ObservableCollection<BallValveJournal> BallValveJournals { get; set; }
    }
}
