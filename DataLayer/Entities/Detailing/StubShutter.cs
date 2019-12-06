using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class StubShutter : BaseDetail
    {
        public StubShutter() : base()
        {
            Name = "Заглушка затвора";
        }

        public int? ShutterReverseId { get; set; }
        public ShutterReverse ShutterReverse { get; set; }

        public IEnumerable<StubShutterJournal> StubShutterJournals { get; set; }
        [NotMapped]
        public IEnumerable<StubShutterTCP> StubShutterTCPs { get; set; }
    }
}
