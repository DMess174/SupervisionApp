using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Entities.Materials;
using System.Collections.ObjectModel;
using DataLayer.Files;

namespace DataLayer.Entities.Detailing
{
    public class CoverSealingRing : BaseEntity
    {
        public CoverSealingRing()
        {
            Name = "Уплотнительное кольцо";
        }

        public CoverSealingRing(CoverSealingRing ring) : base(ring)
        {
            MetalMaterialId = ring.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public CastGateValveCover CastGateValveCover{ get; set; }
        public CoverSleeve CoverSleeve { get; set; }

        public ObservableCollection<CoverSealingRingJournal> CoverSealingRingJournals{ get; set; }
        public ObservableCollection<CoverSealingRingWithFile> Files { get; set; }
    }
}
