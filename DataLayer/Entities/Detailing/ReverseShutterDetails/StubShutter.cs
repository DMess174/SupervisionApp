using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class StubShutter : ReverseShutterDetail
    {
        public StubShutter()
        {
            Name = "Заглушка затвора";
        }

        public int? ReverseShutterId { get; set; }

        public IEnumerable<StubShutterJournal> StubShutterJournals { get; set; }
    }
}
