using DataLayer.Entities.Detailing;
using DataLayer.Entities.Materials.AnticorrosiveCoating;

namespace DataLayer.Entities.AssemblyUnits
{
    public class ReverseShutterWithCoating
    {
        public int Id { get; set; }

        public int ReverseShutterId { get; set; }
        public ReverseShutter ReverseShutter { get; set; }

        public int BaseAnticorrosiveCoatingId { get; set; }
        public BaseAnticorrosiveCoating BaseAnticorrosiveCoating { get; set; }
    }
}
