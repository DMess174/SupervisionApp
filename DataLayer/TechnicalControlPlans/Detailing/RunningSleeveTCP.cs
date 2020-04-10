using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class RunningSleeveTCP : BaseTCP
    {
        public ObservableCollection<RunningSleeveJournal> RunningSleeveJournals { get; set; }
    }
}
