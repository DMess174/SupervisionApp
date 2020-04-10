using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CoverFlange : BaseEntity
    {
        public CoverFlange ()
        {
            Name = "Фланец крышки";
        }
        public CoverFlange(CoverFlange flange) : base(flange)
        {
            MetalMaterialId = flange.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public WeldGateValveCover WeldGateValveCover { get; set; }

        public ObservableCollection<CoverFlangeJournal> CoverFlangeJournals { get; set; }
    }
}
