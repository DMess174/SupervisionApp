using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class SpindleTCP : BaseTCP
    {
        public IEnumerable<SpindleJournal> SpindleJournals { get; set; }
    }
}
