using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class ShaftShutterTCP : BaseTCP
    {
        public IEnumerable<ShaftShutterJournal> ShaftShutterJournals { get; set; }

        [NotMapped]
        public IEnumerable<ShaftShutter> ShaftShutters { get; set; }
    }
}
