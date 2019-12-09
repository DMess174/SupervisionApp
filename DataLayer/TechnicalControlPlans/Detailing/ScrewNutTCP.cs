using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class ScrewNutTCP : BaseTCP
    {
        public IEnumerable<ScrewNutJournal> ScrewNutJournals { get; set; }
    }
}
