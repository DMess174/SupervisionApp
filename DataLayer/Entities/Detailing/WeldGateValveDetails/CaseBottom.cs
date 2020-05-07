using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Materials;
using DataLayer.Files;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CaseBottom : BaseEntity
    {
        public CaseBottom()
        {
            Name = "Днище корпуса";
        }
        public CaseBottom(CaseBottom bottom) : base(bottom)
        {
            MetalMaterialId = bottom.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public WeldGateValveCase WeldGateValveCase { get; set; }

        public ObservableCollection<CaseBottomJournal> CaseBottomJournals { get; set; }
        public ObservableCollection<CaseBottomWithFile> Files { get; set; }
    }
}
