using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.Entities.Detailing.CompactGateValveDetails
{
    public class ShutterGuide : BaseEntity
    {
        public ShutterGuide()
        {
            Name = "Направляющая затвора";
        }
        public ShutterGuide(ShutterGuide guide) : base(guide)
        {
            MetalMaterialId = guide.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? ShutterId { get; set; }
        public Shutter Shutter{ get; set; }

        public ObservableCollection<ShutterGuideJournal> ShutterGuideJournals { get; set; }
    }
}
