using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class StubShutter : ReverseShutterDetail
    {
        public StubShutter()
        {
            Name = "Заглушка затвора";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? ReverseShutterId { get; set; }

        public IEnumerable<StubShutterJournal> StubShutterJournals { get; set; }
    }
}
