using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class SideWall : BaseEntity
    {
        public SideWall()
        {
            Name = "Стенка боковая";
        }

        public SideWall(SideWall wall) : base(wall)
        {
            MetalMaterialId = wall.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? WeldGateValveCaseId { get; set; }
        public WeldGateValveCase WeldGateValveCase { get; set; }

        public ObservableCollection<SideWallJournal> SideWallJournals { get; set; }
    }
}
