using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class WeldNozzle : BaseEntity
    {
        public WeldNozzle()
        {
            Name = "Патрубок";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public FrontWall FrontWall { get; set; }

        public IEnumerable<WeldNozzleJournal> WeldNozzleJournals { get; set; }
    }
}
