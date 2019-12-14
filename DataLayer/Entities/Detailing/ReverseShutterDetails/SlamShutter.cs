using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class SlamShutter : ReverseShutterDetail
    {
        public SlamShutter()
        {
            Name = "Захлопка";
        }

        public IEnumerable<SlamShutterJournal> SlamShutterJournals { get; set; }
    }
}

