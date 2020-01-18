using DataLayer.Journals;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans
{
    public class FactoryInspectionTCP : BaseTCP
    {
        public IEnumerable<FactoryInspectionJournal> FactoryIspectionJournals { get; set; }
    }
}
