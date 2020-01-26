using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.Journals;
using DataLayer.Journals.Detailing.CompactGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.Journals.Materials;
using DataLayer.Journals.Periodical;

namespace DataLayer
{
    public class Inspector : BaseTable
    {
        public string Name { get; set; }

        public string Apointment { get; set; }

        public string Subdivision { get; set; }

        public string Department { get; set; }

        [NotMapped] public string FullName => string.Format($"{Name}\n{Apointment}");

        public IEnumerable<CastGateValveJournal> CastGateValveJournals { get; set; }
        public IEnumerable<CoatingJournal> CoatingJournals { get; set; }
        public IEnumerable<CompactGateValveJournal> CompactGateValveJournals{ get; set; }
        public IEnumerable<SheetGateValveJournal> SheetGateValveJournals { get; set; }
        public IEnumerable<ReverseShutterJournal> ReverseShutterJournals { get; set; }
        public IEnumerable<CastGateValveCaseJournal> CastGateValveCaseJournals { get; set; }
        public IEnumerable<CastGateValveCoverJournal> CastGateValveCoverJournals { get; set; }
        public IEnumerable<ShutterDiskJournal> ShutterDiskJournals { get; set; }
        public IEnumerable<ShutterGuideJournal> ShutterGuideJournals { get; set; }
        public IEnumerable<ShutterJournal> ShutterJournals { get; set; }
        public IEnumerable<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
        public IEnumerable<ReverseShutterCaseJournal> ReverseShutterCaseJournals { get; set; }
        public IEnumerable<ShaftShutterJournal> ShaftShutterJournals { get; set; }
        public IEnumerable<SlamShutterJournal> SlamShutterJournals { get; set; }
        public IEnumerable<SteelSleeveShutterJournal> SteelSleeveShutterJournals { get; set; }
        public IEnumerable<StubShutterJournal> StubShutterJournals { get; set; }
        public IEnumerable<CaseBottomJournal> CaseBottomJournals { get; set; }
        public IEnumerable<CaseFlangeJournal> CaseFlangeJournals { get; set; }
        public IEnumerable<CaseEdgeJournal> CaseEdgeJournals { get; set; }
        public IEnumerable<CompactGateValveCaseJournal> CompactGateValveCaseJournals { get; set; }
        public IEnumerable<CompactGateValveCoverJournal> CompactGateValveCoverJournals { get; set; }
        public IEnumerable<CoverFlangeJournal> CoverFlangeJournals { get; set; }
        public IEnumerable<CoverSleeveJournal> CoverSleeveJournals { get; set; }
        public IEnumerable<FrontWallJournal> FrontWallJournals { get; set; }
        public IEnumerable<SheetGateValveCaseJournal> SheetGateValveCaseJournals { get; set; }
        public IEnumerable<SheetGateValveCoverJournal> SheetGateValveCoverJournals { get; set; }
        public IEnumerable<SideWallJournal> SideWallJournals { get; set; }
        public IEnumerable<WeldNozzleJournal> WeldNozzleJournals { get; set; }
        public IEnumerable<AssemblyUnitSealingJournal> AssemblyUnitSealingJournals { get; set; }
        public IEnumerable<BallValveJournal> BallValveJournals { get; set; }
        public IEnumerable<CounterFlangeJournal> CounterFlangeJournals { get; set; }
        public IEnumerable<CoverSealingRingJournal> CoverSealingRingJournals { get; set; }
        public IEnumerable<FrontalSaddleSealingJournal> FrontalSaddleSealingJournals { get; set; }
        public IEnumerable<GateJournal> GateJournals { get; set; }
        public IEnumerable<NozzleJournal> NozzleJournals { get; set; }
        public IEnumerable<RunningSleeveJournal> RunningSleeveJournals { get; set; }
        public IEnumerable<SaddleJournal> SaddleJournals { get; set; }
        public IEnumerable<ScrewNutJournal> ScrewNutJournals { get; set; }
        public IEnumerable<ScrewStudJournal> ScrewStudJournals { get; set; }
        public IEnumerable<ShearPinJournal> ShearPinJournals { get; set; }
        public IEnumerable<SpindleJournal> SpindleJournals { get; set; }
        public IEnumerable<SpringJournal> SpringJournals { get; set; }
        public IEnumerable<AbovegroundCoatingJournal> AbovegroundCoatingJournals { get; set; }
        public IEnumerable<AbrasiveMaterialJournal> AbrasiveMaterialJournals { get; set; }
        public IEnumerable<UndercoatJournal> UndercoatJournals { get; set; }
        public IEnumerable<UndergroundCoatingJournal> UndergroundCoatingJournals{ get; set; }
        public IEnumerable<ForgingMaterialJournal> ForgingMaterialJournals { get; set; }
        public IEnumerable<PipeMaterialJournal> PipeMaterialJournals { get; set; }
        public IEnumerable<RolledMaterialJournal> RolledMaterialJournals { get; set; }
        public IEnumerable<SheetMaterialJournal> SheetMaterialJournals { get; set; }
        public IEnumerable<WeldingMaterialJournal> WeldingMaterialJournals { get; set; }
        public IEnumerable<ControlWeldJournal> ControlWeldJournals { get; set; }
        public IEnumerable<StoresControlJournal> StoresControlJournals { get; set; }
        public IEnumerable<FactoryInspectionJournal> FactoryInspectionJournals { get; set; }
        public IEnumerable<NDTControlJournal> NDTControls { get; set; }
        public IEnumerable<WeldingProceduresJournal> WeldingProceduresJournals { get; set; }
        public IEnumerable<CoatingChemicalCompositionJournal> CoatingChemicalCompositionJournals { get; set; }
        public IEnumerable<DegreasingChemicalCompositionJournal> DegreasingChemicalCompositionJournals { get; set; }
        public IEnumerable<CoatingPlasticityJournal> CoatingPlasticityJournals { get; set; }
        public IEnumerable<CoatingPorosityJournal> CoatingPorosityJournals { get; set; }
        public IEnumerable<CoatingProtectivePropertiesJournal> CoatingProtectivePropertiesJournals { get; set; }
    }
}
