using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class NozzleTCP : BaseTCP
    {
        public IEnumerable<NozzleJournal> NozzleJournals { get; set; }

        [NotMapped]
        public IEnumerable<Nozzle> Nozzles { get; set; }
    }
}
