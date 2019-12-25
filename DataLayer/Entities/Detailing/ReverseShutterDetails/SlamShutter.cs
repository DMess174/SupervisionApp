using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class SlamShutter : BaseEntity
    {
        public SlamShutter()
        {
            Name = "Захлопка";
        }

        public string Material { get; set; }
        public string Melt { get; set; }

        public ReverseShutter ReverseShutter { get; set; }

        public IEnumerable<SlamShutterJournal> SlamShutterJournals { get; set; }
    }
}

