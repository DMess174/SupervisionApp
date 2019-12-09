using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class FrontalSaddleSealingTCP : BaseTCP
    {
        public IEnumerable<FrontalSaddleSealingJournal> FrontalSaddleSealingJournals { get; set; }
    }
}
