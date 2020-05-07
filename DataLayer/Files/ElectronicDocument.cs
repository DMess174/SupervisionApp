using System;
using System.Collections.ObjectModel;

namespace DataLayer.Files
{
    public class ElectronicDocument : BaseTable
    {
        public FileType FileType { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string FilePath { get; set; }

        public ObservableCollection<AssemblyUnitSealsWithFile> AssemblyUnitSeals{ get; set; }
        public ObservableCollection<BallValvesWithFile> ballValves { get; set; }
        public ObservableCollection<BaseAssemblyUnitWithFile> BaseAssemblyUnits { get; set; }
        public ObservableCollection<BaseAnticorrosiveCoatingWithFile> BaseAnticorrosiveCoatings { get; set; }
        public ObservableCollection<BaseCastingCaseWithFile> BaseCastingCases { get; set; }
        public ObservableCollection<BaseValveCoverWithFile> BaseValveCovers { get; set; }
        public ObservableCollection<BronzeSleeveShutterWithFile> BronzeSleeveShutters { get; set; }
        public ObservableCollection<CaseBottomWithFile> CaseBottoms { get; set; }
        public ObservableCollection<CaseEdgeWithFile> CaseEdges { get; set; }
        public ObservableCollection<CaseFlangeWithFile> CaseFlanges { get; set; }
        public ObservableCollection<ControlWeldWithFile> ControlWelds { get; set; }
        public ObservableCollection<CounterFlangeWithFile> CounterFlanges { get; set; }
        public ObservableCollection<CoverFlangeWithFile> CoverFlanges { get; set; }
        public ObservableCollection<CoverSealingRingWithFile> CoverSealingRings { get; set; }
        public ObservableCollection<CoverSleeveWithFile> CoverSleeves { get; set; }
        public ObservableCollection<FrontalSaddleSealingWithFile> FrontalSaddleSeals { get; set; }
        public ObservableCollection<FrontWallWithFile> FrontWalls { get; set; }
        public ObservableCollection<GateWithFile> Gates { get; set; }
        public ObservableCollection<MetalMaterialWithFile> MetalMaterials { get; set; }
        public ObservableCollection<NozzleWithFile> Nozzles { get; set; }
        public ObservableCollection<PIDWithFile> PIDs { get; set; }
        public ObservableCollection<RunningSleeveWithFile> RunningSleeves { get; set; }
        public ObservableCollection<SaddleWithFile> Saddles { get; set; }
        public ObservableCollection<ScrewNutWithFile> ScrewNuts { get; set; }
        public ObservableCollection<ScrewStudWithFile> ScrewStuds { get; set; }
        public ObservableCollection<ShaftShutterWithFile> ShaftShutters { get; set; }
        public ObservableCollection<ShearPinWithFile> ShearPins { get; set; }
        public ObservableCollection<ShutterDiskWithFile> ShutterDisks { get; set; }
        public ObservableCollection<ShutterGuideWithFile> ShutterGuides { get; set; }
        public ObservableCollection<ShutterWithFile> Shutters { get; set; }
        public ObservableCollection<SideWallWithFile> SideWalls { get; set; }
        public ObservableCollection<SlamShutterWithFile> SlamShutters { get; set; }
        public ObservableCollection<SpecificationWithFile> Specifications { get; set; }
        public ObservableCollection<SpindleWithFile> Spindles { get; set; }
        public ObservableCollection<SpringWithFile> Springs { get; set; }
        public ObservableCollection<SteelSleeveShutterWithFile> SteelSleeveShutters { get; set; }
        public ObservableCollection<StubShutterWithFile> StubShutters { get; set; }
        public ObservableCollection<WeldGateValveCaseWithFile> WeldGateValveCases { get; set; }
        public ObservableCollection<WeldingMaterialWithFile> WeldingMaterials { get; set; }
        public ObservableCollection<WeldNozzleWithFile> WeldNozzles { get; set; }

        public ElectronicDocument()
        {
        }

        public ElectronicDocument(string number, FileType fileType, DateTime date, string filePath)
        {
            Number = number;
            Date = date;
            FilePath = filePath;
            FileType = fileType;
        }
    }
}