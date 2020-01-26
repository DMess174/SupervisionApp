using DataLayer.Journals.Periodical;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class CoatingPlasticityTCP : BaseTCP
    {
        public IEnumerable<CoatingPlasticityJournal> CoatingPlasticityJournals { get; set; }
    }
}
