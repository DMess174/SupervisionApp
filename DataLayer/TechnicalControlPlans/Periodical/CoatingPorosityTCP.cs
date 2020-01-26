using DataLayer.Journals.Periodical;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class CoatingPorosityTCP : BaseTCP
    {
        public IEnumerable<CoatingPorosityJournal> CoatingPorosityJournals { get; set; }
    }
}
