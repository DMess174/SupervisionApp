using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class BronzeSleeveShutterTCP : BaseTCP
    {
        public List<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }

        [NotMapped]
        public List<BronzeSleeveShutter> BronzeSleeveShutters { get; set; }
    }
}
