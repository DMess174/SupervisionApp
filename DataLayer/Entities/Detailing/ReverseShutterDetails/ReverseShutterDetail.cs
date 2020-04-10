using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class ReverseShutterDetail : BaseEntity
    {
        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public ReverseShutter ReverseShutter { get; set; }


        public ReverseShutterDetail() { }
        public ReverseShutterDetail(ReverseShutterDetail detail) : base(detail)
        {
            MetalMaterialId = detail.MetalMaterialId;
        }
    }
}
