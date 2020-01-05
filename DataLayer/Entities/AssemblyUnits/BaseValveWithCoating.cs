using DataLayer.Entities.Materials.AnticorrosiveCoating;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseValveWithCoating
    {
        public int Id { get; set; }

        public int BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public int BaseAnticorrosiveCoatingId { get; set; }
        public BaseAnticorrosiveCoating BaseAnticorrosiveCoating { get; set; }
    }
}
