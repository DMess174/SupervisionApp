using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.Entities.Detailing.CompactGateValveDetails
{
    public class Shutter : BaseEntity
    {
        public Shutter()
        {
            Name = "Затвор";
        }

        public BaseValve BaseValve { get; set; }

        public IEnumerable<ShutterDisk> ShutterDisks { get; set; }
        public IEnumerable<ShutterGuide> ShutterGuides { get; set; }

        public IEnumerable<ShutterJournal> ShutterJournals { get; set; }
    }
}
