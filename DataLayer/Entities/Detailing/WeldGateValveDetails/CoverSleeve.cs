using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CoverSleeve : BaseEntity
    {
        public CoverSleeve()
        {
            Name = "Втулка крышки";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? CoverSealingRingId { get; set; }
        public CoverSealingRing CoverSealingRing { get; set; }

        public IEnumerable<CoverSleeveJournal> CoverSleeveJournals { get; set; }
    }
}
