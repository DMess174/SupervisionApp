using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class SteelSleeveShutter : BaseDetail
    {
        public SteelSleeveShutter()
        {
            Name = "Втулка стальная";
        }

        public int? ReverseShutterId { get; set; }
        public ReverseShutter ReverseShutter { get; set; }

        public IEnumerable<SteelSleeveShutterJournal> SteelSleeveShutterJournals{ get; set; }
    }
}
