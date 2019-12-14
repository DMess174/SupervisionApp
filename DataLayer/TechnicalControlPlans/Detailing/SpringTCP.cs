using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class SpringTCP : BaseTCP
    {
        public IEnumerable<SpringJournal> SpringJournals { get; set; }
    }
}
