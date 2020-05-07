using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Materials;
using DataLayer.Files;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class WeldNozzle : BaseEntity
    {
        public WeldNozzle()
        {
            Name = "Патрубок";
        }

        public WeldNozzle(WeldNozzle nozzle) : base(nozzle)
        {
            MetalMaterialId = nozzle.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public FrontWall FrontWall { get; set; }

        public ObservableCollection<WeldNozzleJournal> WeldNozzleJournals { get; set; }
        public ObservableCollection<WeldNozzleWithFile> Files { get; set; }
    }
}
