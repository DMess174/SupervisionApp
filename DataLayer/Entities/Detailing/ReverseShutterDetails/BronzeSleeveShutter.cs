using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class BronzeSleeveShutter : ReverseShutterDetail
    {
        public BronzeSleeveShutter()
        {
            Name = "Втулка бронзовая";
        }

        public string Material { get; set; }
        public string Melt { get; set; }

        public int? ReverseShutterId { get; set; }

        public IEnumerable<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
    }
}
