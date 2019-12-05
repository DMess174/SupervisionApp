using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class ValveCaseTCP : BaseTCP
    {
        public List<ValveCaseJournal> ValveCaseJournals { get; set; }

        [NotMapped]
        public List<ValveCase> ValveCases { get; set; }
    }
}
