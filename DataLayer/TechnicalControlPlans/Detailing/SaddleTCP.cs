using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class SaddleTCP : BaseTCP
    {
        public IEnumerable<SaddleJournal> SaddleJournals { get; set; }
    }
}
