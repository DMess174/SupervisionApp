using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class CounterFlangeTCP : BaseTCP
    {
        public IEnumerable<CounterFlangeJournal> CounterFlangeJournals { get; set; }
    }
}
