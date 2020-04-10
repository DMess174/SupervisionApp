using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class FrontWall : BaseEntity
    {
        public FrontWall()
        {
            Name = "Стенка лицевая";
        }
        public FrontWall(FrontWall wall) : base(wall)
        {
            MetalMaterialId = wall.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? WeldGateValveCaseId { get; set; }
        public WeldGateValveCase WeldGateValveCase { get; set; }

        public int? WeldNozzleId { get; set; }
        public WeldNozzle WeldNozzle { get; set; }

        public ObservableCollection<FrontWallJournal> FrontWallJournals{ get; set; }
    }
}
