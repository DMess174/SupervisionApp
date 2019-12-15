using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CaseFlange : BaseDetail
    {
        public CaseFlange()
        {
            Name = "Фланец корпуса";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public WeldGateValveCase WeldGateValveCase { get; set; }

        public IEnumerable<CaseFlangeJournal> CaseFlangeJournals { get; set; }
    }
}
