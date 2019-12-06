using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class StubShutterTCP : BaseTCP
    {
        public IEnumerable<StubShutterJournal> StubShutterJournals{ get; set; }

        [NotMapped]
        public IEnumerable<StubShutter> StubShutters{ get; set; }
    }
}
