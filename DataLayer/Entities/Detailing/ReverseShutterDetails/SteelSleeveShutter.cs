using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class SteelSleeveShutter : ReverseShutterDetail
    {
        public SteelSleeveShutter()
        {
            Name = "Втулка стальная";
        }

        public int? ReverseShutterId { get; set; }

        public IEnumerable<SteelSleeveShutterJournal> SteelSleeveShutterJournals{ get; set; }
    }
}
