using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
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

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? ReverseShutterId { get; set; }
        public ReverseShutter ReverseShutter { get; set; }

        public IEnumerable<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
    }
}
