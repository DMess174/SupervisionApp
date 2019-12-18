using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class ReverseShutterDetail : BaseEntity
    {
        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public ReverseShutter ReverseShutter { get; set; }
    }
}
