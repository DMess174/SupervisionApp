using DataLayer.Entities.AssemblyUnits;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class WeldGateValveCover : BaseValveCover
    {
        public int? CoverFlangeId { get; set; }
        public CoverFlange CoverFlange { get; set; }

        public int? CoverSleeveId { get; set; }
        public CoverSleeve CoverSleeve { get; set; }

        public BaseWeldValve BaseWeldValve { get; set; }

        public WeldGateValveCover()
        {
        }
        public WeldGateValveCover(WeldGateValveCover cover) : base(cover)
        {

        }
    }
}
