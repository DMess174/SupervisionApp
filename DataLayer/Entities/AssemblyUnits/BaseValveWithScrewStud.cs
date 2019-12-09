using DataLayer.Entities.Detailing;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseValveWithScrewStud
    {
        public int Id { get; set; }

        public int BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public int ScrewStudId { get; set; }
        public ScrewStud ScrewStud{ get; set; }

        public int ScrewStudAmount { get; set; }
    }
}
