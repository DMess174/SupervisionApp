using DataLayer.Entities.Detailing;
using System.Collections.Generic;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseValve : BaseAssemblyUnit
    {
        public BaseValve()
        {
        }
        public BaseValve(BaseValve valve) : base(valve)
        {

        }

        public int? GateId { get; set; }
        public Gate Gate { get; set; }

        public int? ShutterId { get; set; }
        public Shutter Shutter { get; set; }

        public ObservableCollection<Saddle> Saddles { get; set; }
        public ObservableCollection<ShearPin> ShearPins { get; set; }
        public ObservableCollection<BallValve> BallValves { get; set; }
        public ObservableCollection<CounterFlange> CounterFlanges { get; set; }

        public ObservableCollection<BaseValveWithSealing> BaseValveWithSeals { get; set; }
        public ObservableCollection<BaseValveWithScrewNut> BaseValveWithScrewNuts { get; set; }
        public ObservableCollection<BaseValveWithScrewStud> BaseValveWithScrewStuds { get; set; }
        public ObservableCollection<BaseValveWithSpring> BaseValveWithSprings { get; set; }
        public ObservableCollection<BaseValveWithCoating> BaseValveWithCoatings { get; set; }
    }
}
