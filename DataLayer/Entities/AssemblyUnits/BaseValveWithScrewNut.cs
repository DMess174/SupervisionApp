using DataLayer.Entities.Detailing;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseValveWithScrewNut
    {
        public int Id { get; set; }

        public int BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public int ScrewNutId { get; set; }
        public ScrewNut ScrewNut{ get; set; }

        public int ScrewNutAmount { get; set; }
    }
}
