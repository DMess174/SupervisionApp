using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class StubShutter : BaseDetail
    {
        public StubShutter()
        {
            Name = "Заглушка затвора";
        }

        public int? ReverseShutterId { get; set; }
        public ReverseShutter ReverseShutter { get; set; }

        public IEnumerable<StubShutterJournal> StubShutterJournals { get; set; }
    }
}
