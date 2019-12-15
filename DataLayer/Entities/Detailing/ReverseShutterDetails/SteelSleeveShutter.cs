using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class SteelSleeveShutter : ReverseShutterDetail
    {
        public SteelSleeveShutter()
        {
            Name = "Втулка стальная";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? ReverseShutterId { get; set; }

        public IEnumerable<SteelSleeveShutterJournal> SteelSleeveShutterJournals{ get; set; }
    }
}
