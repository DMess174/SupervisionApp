using DataLayer.Entities.Detailing;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseValveWithSealing
    {
        public int Id { get; set; }

        public int BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public int AssemblyUnitSealingId { get; set; }
        public AssemblyUnitSealing AssemblyUnitSealing { get; set; }
    }
}
