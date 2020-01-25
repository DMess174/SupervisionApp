using DataLayer.Journals.Periodical;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class NDTControlTCP : BaseTCP
    {
        public IEnumerable<NDTControlJournal> NDTControlJournals { get; set; }
    }
}
