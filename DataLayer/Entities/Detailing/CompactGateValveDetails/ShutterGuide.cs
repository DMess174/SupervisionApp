using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.Entities.Detailing.CompactGateValveDetails
{
    public class ShutterGuide : BaseDetail
    {
        public ShutterGuide()
        {
            Name = "Направляющая затвора";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? ShutterId { get; set; }
        public Shutter Shutter{ get; set; }

        public IEnumerable<ShutterGuideJournal> ShutterGuideJournals { get; set; }
    }
}
