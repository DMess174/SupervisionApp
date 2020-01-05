using DataLayer.Entities.Detailing;
using System.Collections.Generic;
using DataLayer.Entities.Detailing.CompactGateValveDetails;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseValve : BaseAssemblyUnit
    {
        public int? GateId { get; set; }
        public Gate Gate { get; set; }

        public int? ShutterId { get; set; }
        public Shutter Shutter { get; set; }

        public IEnumerable<Saddle> Saddles { get; set; }
        public IEnumerable<ShearPin> ShearPins { get; set; }
        public IEnumerable<BallValve> BallValves { get; set; }
        public IEnumerable<CounterFlange> CounterFlanges { get; set; }

        public IEnumerable<BaseValveWithSealing> BaseValveWithSeals { get; set; }
        public IEnumerable<BaseValveWithScrewNut> BaseValveWithScrewNuts { get; set; }
        public IEnumerable<BaseValveWithScrewStud> BaseValveWithScrewStuds { get; set; }
        public IEnumerable<BaseValveWithSpring> BaseValveWithSprings { get; set; }
        public IEnumerable<BaseValveWithCoating> BaseValveWithCoatings { get; set; }
    }
}
