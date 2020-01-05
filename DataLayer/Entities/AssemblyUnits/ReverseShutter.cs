using System.Collections.Generic;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class ReverseShutter : BaseAssemblyUnit
    {
        public ReverseShutter()
        {
            Name = "ЗО";
        }

        public int? ReverseShutterCaseId { get; set; }
        public ReverseShutterCase ReverseShutterCase { get; set; }

        public int? ShaftShutterId { get; set; }
        public ShaftShutter ShaftShutter { get; set; }

        public int? SlamShutterId { get; set; }
        public SlamShutter SlamShutter { get; set; }

        public IEnumerable<BronzeSleeveShutter> BronzeSleeveShutters { get; set; }
        public IEnumerable<SteelSleeveShutter> SteelSleeveShutters { get; set; }
        public IEnumerable<StubShutter> StubShutters { get; set; }
        public IEnumerable<ReverseShutterWithCoating> ReverseShutterWithCoatings { get; set; }

        public IEnumerable<ReverseShutterJournal> ReverseShutterJournals { get; set; }
    }
}
