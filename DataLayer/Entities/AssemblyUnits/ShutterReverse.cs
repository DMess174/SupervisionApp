using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class ShutterReverse : BaseAssemblyUnit
    {
        public ShutterReverse() : base()
        {
            Name = "Затвор";
        }

        public int? ShutterCaseId { get; set; }
        public ShutterCase ShutterCase { get; set; }

        public int? ShaftShutterId { get; set; }
        public ShaftShutter ShaftShutter { get; set; }

        public int? SlamShutterId { get; set; }
        public SlamShutter SlamShutter { get; set; }

        public IEnumerable<BronzeSleeveShutter> BronzeSleeveShutters { get; set; }

        public IEnumerable<SteelSleeveShutter> SteelSleeveShutters { get; set; }

        public IEnumerable<StubShutter> StubShutters { get; set; }

        public IEnumerable<ShutterReverseJournal> ShutterReverseJournals{ get; set; }
        [NotMapped]
        public IEnumerable<ShutterReverseTCP> ShutterReverseTCPs{ get; set; }
    }
}
