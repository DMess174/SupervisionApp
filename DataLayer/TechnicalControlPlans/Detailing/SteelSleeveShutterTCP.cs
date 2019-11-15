using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class SteelSleeveShutterTCP : BaseTCP
    {
        public List<SteelSleeveShutterJournal> SteelSleeveShutterJournals { get; set; }

        [NotMapped]
        public List<SteelSleeveShutter> SteelSleeveShutters { get; set; }
    }
}
