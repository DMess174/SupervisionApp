using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class BronzeSleeveShutter : ReverseShutterDetail
    {
        public BronzeSleeveShutter()
        {
            Name = "Втулка бронзовая";
        }

        public int? ReverseShutterId { get; set; }

        public IEnumerable<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
    }
}
