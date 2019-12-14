using DataLayer.Entities.Detailing;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseValveWithSpring
    {
        public int Id { get; set; }

        public int BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public int SpringId { get; set; }
        public Spring Spring { get; set; }

        public int SpringAmount { get; set; }
    }
}
