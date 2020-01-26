using DataLayer.Journals.Periodical;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class CoatingProtectivePropertiesTCP : BaseTCP
    {
        public IEnumerable<CoatingProtectivePropertiesJournal> CoatingProtectivePropertiesJournals { get; set; }
    }
}
