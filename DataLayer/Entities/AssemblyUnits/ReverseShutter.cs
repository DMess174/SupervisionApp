using System.Collections.ObjectModel;
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
        public ReverseShutter(ReverseShutter shutter) : base(shutter)
        {
        }

        public int? ReverseShutterCaseId { get; set; }
        public ReverseShutterCase ReverseShutterCase { get; set; }

        public int? ShaftShutterId { get; set; }
        public ShaftShutter ShaftShutter { get; set; }

        public int? SlamShutterId { get; set; }
        public SlamShutter SlamShutter { get; set; }

        public ObservableCollection<BronzeSleeveShutter> BronzeSleeveShutters { get; set; }
        public ObservableCollection<SteelSleeveShutter> SteelSleeveShutters { get; set; }
        public ObservableCollection<StubShutter> StubShutters { get; set; }
        public ObservableCollection<ReverseShutterWithCoating> ReverseShutterWithCoatings { get; set; }

        public ObservableCollection<ReverseShutterJournal> ReverseShutterJournals { get; set; }
    }
}
