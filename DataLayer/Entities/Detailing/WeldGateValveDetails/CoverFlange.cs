using System.Collections.Generic;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CoverFlange : BaseDetail
    {
        public CoverFlange ()
        {
            Name = "Фланец крышки";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public WeldGateValveCover WeldGateValveCover { get; set; }

        public IEnumerable<CoverFlangeJournal> CoverFlangeJournals { get; set; }
    }
}
