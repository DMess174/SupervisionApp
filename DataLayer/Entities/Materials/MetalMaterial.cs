using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials
{
    public class MetalMaterial : BaseTable
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Material { get; set; }
        public string Melt { get; set; }
        public string Certificate { get; set; }
        public string Batch { get; set; }
        public string MaterialCertificateNumber { get; set; }
        public string Status { get; set; }
        public string FirstSize { get; set; }
        public string SecondSize { get; set; }
        public string ThirdSize { get; set; }

        public IEnumerable<Spindle> Spindles { get; set; }
        public IEnumerable<Saddle> Saddles { get; set; }
        public IEnumerable<Nozzle> Nozzles { get; set; }
        public IEnumerable<Gate> Gates { get; set; }
        public IEnumerable<WeldNozzle> WeldNozzles { get; set; }
        public IEnumerable<SideWall> SideWalls { get; set; }
        public IEnumerable<FrontWall> FrontWalls { get; set; }
        public IEnumerable<CoverSleeve> CoverSleeves { get; set; }
        public IEnumerable<CoverFlange> CoverFlanges { get; set; }
        public IEnumerable<CaseFlange> CaseFlanges { get; set; }
        public IEnumerable<CaseBottom> CaseBottoms { get; set; }
        public IEnumerable<BronzeSleeveShutter> BronzeSleeveShutters { get; set; }
        public IEnumerable<ShaftShutter> ShaftShutters { get; set; }
        public IEnumerable<SteelSleeveShutter> SteelSleeveShutters { get; set; }
        public IEnumerable<StubShutter> StubShutters { get; set; }
        public IEnumerable<ShutterDisk> ShutterDisks { get; set; }
        public IEnumerable<ShutterGuide> ShutterGuides { get; set; }
        public IEnumerable<CounterFlange> CounterFlanges { get; set; }
        public IEnumerable<CoverSealingRing> CoverSealingRings { get; set; }
    }
}
