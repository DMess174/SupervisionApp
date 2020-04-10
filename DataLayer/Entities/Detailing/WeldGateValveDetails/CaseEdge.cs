using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public CaseEdge(CaseEdge edge) : base(edge)
        {
            MetalMaterialId = edge.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? WeldGateValveCaseId { get; set; }
        public WeldGateValveCase WeldGateValveCase { get; set; }

        public ObservableCollection<CaseEdgeJournal> CaseEdgeJournals { get; set; }
    }
}
