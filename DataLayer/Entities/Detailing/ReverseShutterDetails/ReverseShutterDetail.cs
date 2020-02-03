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
        public ReverseShutterDetail(ReverseShutterDetail detail)
        {
            Certificate = detail.Certificate;
            Number = detail.Number;
            Drawing = detail.Drawing;
            Status = detail.Status;
            Comment = detail.Comment;
            MetalMaterial = detail.MetalMaterial;
        }
    }
}
