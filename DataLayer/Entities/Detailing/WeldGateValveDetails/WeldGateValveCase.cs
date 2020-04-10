using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<FrontWall> FrontWalls { get; set; }
        public ObservableCollection<SideWall> SideWalls { get; set; }
        public ObservableCollection<CaseEdge> CaseEdges { get; set; }

        public BaseWeldValve BaseWeldValve { get; set; }

        public WeldGateValveCase()
        {
        }
        public WeldGateValveCase(WeldGateValveCase weldCase) : base(weldCase)
        {
        }
    }
}
