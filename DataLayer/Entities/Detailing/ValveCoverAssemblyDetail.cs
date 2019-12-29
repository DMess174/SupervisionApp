using DataLayer.Entities.Materials;

namespace DataLayer.Entities.Detailing
{
    public class ValveCoverAssemblyDetail : BaseEntity
    {
        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public BaseValveCover BaseValveCover { get; set; }
    }
}
