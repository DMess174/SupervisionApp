using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class ShutterCaseTCP : BaseTCP
    {
        public IEnumerable<ShutterCaseJournal> CaseShutterJournals { get; set; }

        [NotMapped]
        public IEnumerable<ShutterCase> CaseShutters { get; set; }
    }
}
