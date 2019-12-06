using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class SteelSleeveShutterTCP : BaseTCP
    {
        public IEnumerable<SteelSleeveShutterJournal> SteelSleeveShutterJournals { get; set; }

        [NotMapped]
        public IEnumerable<SteelSleeveShutter> SteelSleeveShutters { get; set; }
    }
}
