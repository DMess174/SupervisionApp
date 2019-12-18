using System.Collections.Generic;
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

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? WeldGateValveCaseId { get; set; }
        public WeldGateValveCase GetWeldGateValveCase { get; set; }

        public IEnumerable<SideWallJournal> SideWallJournals { get; set; }
    }
}
