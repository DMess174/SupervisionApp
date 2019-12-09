using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class CoverSealingRingTCP : BaseTCP
    {
        public IEnumerable<CoverSealingRingJournal> CoverSealingRingJournals { get; set; }
    }
}
