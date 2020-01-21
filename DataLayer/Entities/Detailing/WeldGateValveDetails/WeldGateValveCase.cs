using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class WeldGateValveCase : BaseCase
    {
        public string Diameter { get; set; }
        public string Thickness { get; set; }

        public int? CaseFlangeId { get; set; }
        public CaseFlange CaseFlange { get; set; }

        public int? CaseBottomId { get; set; }
        public CaseBottom CaseBottom { get; set; }

        public IEnumerable<FrontWall> FrontWalls { get; set; }
        public IEnumerable<SideWall> SideWalls { get; set; }
        public IEnumerable<CaseEdge> CaseEdges { get; set; }

        public BaseWeldValve BaseWeldValve { get; set; }
    }
}
