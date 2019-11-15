using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class SlamShutterTCP : BaseTCP
    {
        public List<SlamShutterJournal> SlamShutterJournals { get; set; }

        [NotMapped]
        public List<SlamShutter> SlamShutters { get; set; }
    }
}
