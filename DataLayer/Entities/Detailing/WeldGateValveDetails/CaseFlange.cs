using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Materials;
using DataLayer.Files;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CaseFlange : BaseEntity
    {
        public CaseFlange()
        {
            Name = "Фланец корпуса";
        }
        public CaseFlange(CaseFlange flange) : base(flange)
        {
            MetalMaterialId = flange.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public WeldGateValveCase WeldGateValveCase { get; set; }

        public ObservableCollection<CaseFlangeJournal> CaseFlangeJournals { get; set; }
        public ObservableCollection<CaseFlangeWithFile> Files { get; set; }
    }
}
