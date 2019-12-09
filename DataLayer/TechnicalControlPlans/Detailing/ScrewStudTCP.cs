using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class ScrewStudTCP : BaseTCP
    {
        public IEnumerable<ScrewStudJournal> ScrewStudJournals { get; set; }
    }
}
