using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class ShaftShutter : ReverseShutterDetail
    {
        public ShaftShutter()
        {
            Name = "Ось затвора";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public IEnumerable<ShaftShutterJournal> ShaftShutterJournals { get; set; }
    }
}
