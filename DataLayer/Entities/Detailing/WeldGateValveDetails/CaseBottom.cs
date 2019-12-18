using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CaseBottom : BaseEntity
    {
        public CaseBottom()
        {
            Name = "Днище корпуса";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public WeldGateValveCase WeldGateValveCase { get; set; }

        public IEnumerable<CaseBottomJournal> CaseBottomJournals { get; set; }
    }
}
