using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CaseEdge : BaseEntity
    {
        public CaseEdge()
        {
            Name = "Ребро";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? WeldGateValveCaseId { get; set; }
        public WeldGateValveCase WeldGateValveCase { get; set; }

        public IEnumerable<CaseEdgeJournal> CaseEdgeJournals { get; set; }
    }
}
