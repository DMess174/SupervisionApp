using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class FrontWall : BaseDetail
    {
        public FrontWall()
        {
            Name = "Стенка лицевая";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? WeldGateValveCaseId { get; set; }
        public WeldGateValveCase WeldGateValveCase { get; set; }

        public int? WeldNozzleId { get; set; }
        public WeldNozzle WeldNozzle { get; set; }

        public IEnumerable<FrontWallJournal> FrontWallJournals{ get; set; }
    }
}
