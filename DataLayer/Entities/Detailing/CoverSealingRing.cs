using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Entities.Materials;

namespace DataLayer.Entities.Detailing
{
    public class CoverSealingRing : BaseEntity
    {
        public CoverSealingRing()
        {
            Name = "Уплотнительное кольцо";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public CastGateValveCover CastGateValveCover{ get; set; }
        public CoverSleeve CoverSleeve { get; set; }

        public IEnumerable<CoverSealingRingJournal> CoverSealingRingJournals{ get; set; }
    }
}
