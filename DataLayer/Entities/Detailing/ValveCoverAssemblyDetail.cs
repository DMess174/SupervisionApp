using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class ValveCoverAssemblyDetail : BaseEntity
    {
        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public BaseValveCover BaseValveCover { get; set; }

    }
}
