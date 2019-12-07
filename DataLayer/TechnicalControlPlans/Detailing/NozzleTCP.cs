using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class NozzleTCP : BaseTCP
    {
        public IEnumerable<NozzleJournal> NozzleJournals { get; set; }
    }
}
