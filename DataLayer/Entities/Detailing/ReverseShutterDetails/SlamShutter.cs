using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class SlamShutter : BaseDetail
    {
        public SlamShutter() : base()
        {
            Name = "Захлопка";
        }

        public ReverseShutter ReverseShutter { get; set; }

        public IEnumerable<SlamShutterJournal> SlamShutterJournals { get; set; }
    }
}

