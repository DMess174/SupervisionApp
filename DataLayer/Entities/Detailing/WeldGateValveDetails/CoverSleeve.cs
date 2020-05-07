using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Materials;
using DataLayer.Files;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CoverSleeve : BaseEntity
    {
        public CoverSleeve()
        {
            Name = "Втулка крышки";
        }

        public CoverSleeve(CoverSleeve sleeve) : base(sleeve)
        {
            MetalMaterialId = sleeve.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? CoverSealingRingId { get; set; }
        public CoverSealingRing CoverSealingRing { get; set; }

        public WeldGateValveCover WeldGateValveCover { get; set; }

        public ObservableCollection<CoverSleeveJournal> CoverSleeveJournals { get; set; }
        public ObservableCollection<CoverSleeveWithFile> Files { get; set; }
    }
}
