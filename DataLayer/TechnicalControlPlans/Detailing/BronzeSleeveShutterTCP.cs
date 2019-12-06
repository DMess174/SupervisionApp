using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class BronzeSleeveShutterTCP : BaseTCP
    {
        public IEnumerable<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }

        [NotMapped]
        public IEnumerable<BronzeSleeveShutter> BronzeSleeveShutters { get; set; }
    }
}
