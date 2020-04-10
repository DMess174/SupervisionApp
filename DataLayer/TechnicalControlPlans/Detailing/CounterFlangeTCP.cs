using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class CounterFlangeTCP : BaseTCP
    {
        public ObservableCollection<CounterFlangeJournal> CounterFlangeJournals { get; set; }
    }
}
