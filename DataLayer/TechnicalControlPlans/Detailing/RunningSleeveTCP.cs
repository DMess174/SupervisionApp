using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class RunningSleeveTCP : BaseTCP
    {
        public IEnumerable<RunningSleeveJournal> RunningSleeveJournals { get; set; }
    }
}
