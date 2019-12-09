using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseWeldValve : BaseValve
    {
        public int? WeldGateValveCoverId { get; set; }
        public WeldGateValveCover WeldGateValveCover { get; set; }

        public int? WeldGateValveCaseId { get; set; }
        public WeldGateValveCase WeldGateValveCase { get; set; }
    }
}
