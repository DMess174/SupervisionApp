using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class NozzleTCP : BaseTCP
    {
        public List<NozzleJournal> NozzleJournals { get; set; }

        [NotMapped]
        public List<Nozzle> Nozzles { get; set; }
    }
}
