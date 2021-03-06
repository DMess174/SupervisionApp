﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DataLayer.TechnicalControlPlans.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.Journals;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using DataLayer.Journals.Materials;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans;
using DataLayer.Entities.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;
using DataLayer.Journals.Periodical;
using DataLayer.Files;
using System;

namespace DataLayer
{
    public sealed class DesktopDataContext : DbContext
    {
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Specification> Specifications{ get; set; }
        public DbSet<PID> PIDs { get; set; }
        public DbSet<PIDTCP> PIDTCPs { get; set; }
        public DbSet<PIDJournal> PIDJournals { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }
        public DbSet<JournalNumber> JournalNumbers { get; set; }

        public DbSet<CoatingPlasticityTCP> CoatingPlasticityTCPs { get; set; }
        public DbSet<CoatingPlasticityJournal> CoatingPlasticityJournals { get; set; }

        public DbSet<CoatingPorosityTCP> CoatingPorosityTCPs { get; set; }
        public DbSet<CoatingPorosityJournal> CoatingPorosityJournals { get; set; }

        public DbSet<CoatingProtectivePropertiesTCP> CoatingProtectivePropertiesTCPs { get; set; }
        public DbSet<CoatingProtectivePropertiesJournal> CoatingProtectivePropertiesJournals { get; set; }

        public DbSet<DegreasingChemicalCompositionTCP> DegreasingChemicalCompositionTCPs { get; set; }
        public DbSet<DegreasingChemicalCompositionJournal> DegreasingChemicalCompositionJournals { get; set; }

        public DbSet<CoatingChemicalCompositionTCP> CoatingChemicalCompositionTCPs { get; set; }
        public DbSet<CoatingChemicalCompositionJournal> CoatingChemicalCompositionJournals { get; set; }

        public DbSet<StoresControlTCP> StoresControlTCPs { get; set; }
        public DbSet<StoresControlJournal> StoresControlJournals { get; set; }

        public DbSet<FactoryInspectionTCP> FactoryInspectionTCPs { get; set; }
        public DbSet<FactoryInspectionJournal> FactoryInspectionJournals { get; set; }

        public DbSet<WeldingProcedures> WeldingProcedures { get; set; }
        public DbSet<WeldingProceduresTCP> WeldingProceduresTCPs { get; set; }
        public DbSet<WeldingProceduresJournal> WeldingProceduresJournals { get; set; }

        public DbSet<NDTControl> NDTControls { get; set; }
        public DbSet<NDTControlTCP> NDTControlTCPs { get; set; }
        public DbSet<NDTControlJournal> NDTControlJournals { get; set; }

        public DbSet<ControlWeld> ControlWelds { get; set; }
        public DbSet<ControlWeldTCP> ControlWeldTCPs { get; set; }
        public DbSet<ControlWeldJournal> ControlWeldJournals { get; set; }

        public DbSet<CoatingTCP> CoatingTCPs { get; set; }
        public DbSet<CoatingJournal> CoatingJournals { get; set; }

        public DbSet<BronzeSleeveShutter> BronzeSleeveShutters { get; set; }
        public DbSet<BronzeSleeveShutterTCP> BronzeSleeveShutterTCPs { get; set; }
        public DbSet<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
        
        public DbSet<ReverseShutterCase> ReverseShutterCases { get; set; }
        public DbSet<ReverseShutterCaseTCP> ReverseShutterCaseTCPs { get; set; }
        public DbSet<ReverseShutterCaseJournal> ReverseShutterCaseJournals { get; set; }

        public DbSet<Nozzle> Nozzles { get; set; }
        public DbSet<NozzleTCP> NozzleTCPs { get; set; }
        public DbSet<NozzleJournal> NozzleJournals { get; set; }

        public DbSet<ShaftShutter> ShaftShutters { get; set; }
        public DbSet<ShaftShutterTCP> ShaftShutterTCPs { get; set; }
        public DbSet<ShaftShutterJournal> ShaftShutterJournals { get; set; }
        
        public DbSet<ReverseShutter> ReverseShutters { get; set; }
        public DbSet<ReverseShutterTCP> ReverseShutterTCPs { get; set; }
        public DbSet<ReverseShutterJournal> ReverseShutterJournals { get; set; }
        public DbSet<ReverseShutterWithCoating> ReverseShutterWithCoatings { get; set; }

        public DbSet<SlamShutter> SlamShutters { get; set; }
        public DbSet<SlamShutterTCP> SlamShutterTCPs { get; set; }
        public DbSet<SlamShutterJournal> SlamShutterJournals { get; set; }

        public DbSet<SteelSleeveShutter> SteelSleeveShutters { get; set; }
        public DbSet<SteelSleeveShutterTCP> SteelSleeveShutterTCPs { get; set; }
        public DbSet<SteelSleeveShutterJournal> SteelSleeveShutterJournals { get; set; }

        public DbSet<StubShutter> StubShutters { get; set; }
        public DbSet<StubShutterTCP> StubShutterTCPs { get; set; }
        public DbSet<StubShutterJournal> StubShutterJournals { get; set; }

        public DbSet<CastGateValveCase> CastGateValveCases { get; set; }
        public DbSet<CastGateValveCaseTCP> CastGateValveCaseTCPs { get; set; }
        public DbSet<CastGateValveCaseJournal> CastGateValveCaseJournals { get; set; }

        public DbSet<CastGateValve> CastGateValves { get; set; }
        public DbSet<CastGateValveTCP> CastGateValveTCPs { get; set; }
        public DbSet<CastGateValveJournal> CastGateValveJournals { get; set; }
        public DbSet<BaseValveWithCoating> BaseValveWithCoatings { get; set; }

        public DbSet<BaseAssemblyUnit> BaseAssemblyUnit { get; set; }
        public DbSet<SheetGateValve> SheetGateValves { get; set; }
        public DbSet<SheetGateValveTCP> SheetGateValveTCPs { get; set; }
        public DbSet<SheetGateValveJournal> SheetGateValveJournals { get; set; }

        public DbSet<CompactGateValve> CompactGateValves { get; set; }
        public DbSet<CompactGateValveTCP> CompactGateValveTCPs { get; set; }
        public DbSet<CompactGateValveJournal> CompactGateValveJournals { get; set; }

        public DbSet<CastGateValveCover> CastGateValveCovers { get; set; }
        public DbSet<CastGateValveCoverTCP> CastGateValveCoverTCPs { get; set; }
        public DbSet<CastGateValveCoverJournal> CastGateValveCoverJournals { get; set; }

        public DbSet<Spindle> Spindles { get; set; }
        public DbSet<SpindleTCP> SpindleTCPs { get; set; }
        public DbSet<SpindleJournal> SpindleJournals { get; set; }

        public DbSet<CoverSealingRing> CoverSealingRings { get; set; }
        public DbSet<CoverSealingRingTCP> CoverSealingRingTCPs { get; set; }
        public DbSet<CoverSealingRingJournal> CoverSealingRingJournals { get; set; }

        public DbSet<CoverSleeve> CoverSleeves { get; set; }
        public DbSet<CoverSleeveTCP> CoverSleeveTCPs { get; set; }
        public DbSet<CoverSleeveJournal> CoverSleeveJournals { get; set; }

        public DbSet<FrontWall> FrontWalls { get; set; }
        public DbSet<FrontWallTCP> FrontWallTCPs { get; set; }
        public DbSet<FrontWallJournal> FrontWallJournals { get; set; }

        public DbSet<SideWall> SideWalls { get; set; }
        public DbSet<SideWallTCP> SideWallTCPs { get; set; }
        public DbSet<SideWallJournal> SideWallJournals { get; set; }

        public DbSet<CaseEdge> CaseEdges { get; set; }
        public DbSet<CaseEdgeTCP> CaseEdgeTCPs { get; set; }
        public DbSet<CaseEdgeJournal> CaseEdgeJournals { get; set; }

        public DbSet<RunningSleeve> RunningSleeves { get; set; }
        public DbSet<RunningSleeveTCP> RunningSleeveTCPs { get; set; }
        public DbSet<RunningSleeveJournal> RunningSleeveJournals { get; set; }

        public DbSet<CoverFlange> CoverFlanges { get; set; }
        public DbSet<CoverFlangeTCP> CoverFlangeTCPs { get; set; }
        public DbSet<CoverFlangeJournal> CoverFlangeJournals { get; set; }

        public DbSet<CompactGateValveCover> CompactGateValveCovers { get; set; }
        public DbSet<CompactGateValveCoverTCP> CompactGateValveCoverTCPs { get; set; }
        public DbSet<CompactGateValveCoverJournal> CompactGateValveCoverJournals { get; set; }

        public DbSet<SheetGateValveCover> SheetGateValveCovers { get; set; }
        public DbSet<SheetGateValveCoverTCP> SheetGateValveCoverTCPs { get; set; }
        public DbSet<SheetGateValveCoverJournal> SheetGateValveCoverJournals { get; set; }

        public DbSet<Gate> Gates { get; set; }
        public DbSet<GateTCP> GateTCPs { get; set; }
        public DbSet<GateJournal> GateJournals { get; set; }

        public DbSet<Saddle> Saddles { get; set; }
        public DbSet<SaddleTCP> SaddleTCPs { get; set; }
        public DbSet<SaddleJournal> SaddleJournals { get; set; }

        public DbSet<CaseBottom> CaseBottoms { get; set; }
        public DbSet<CaseBottomTCP> CaseBottomTCPs { get; set; }
        public DbSet<CaseBottomJournal> CaseBottomJournals { get; set; }

        public DbSet<CaseFlange> CaseFlanges { get; set; }
        public DbSet<CaseFlangeTCP> CaseFlangeTCPs { get; set; }
        public DbSet<CaseFlangeJournal> CaseFlangeJournals { get; set; }

        public DbSet<WeldNozzle> WeldNozzles { get; set; }
        public DbSet<WeldNozzleTCP> WeldNozzleTCPs { get; set; }
        public DbSet<WeldNozzleJournal> WeldNozzleJournals { get; set; }

        public DbSet<SheetGateValveCase> SheetGateValveCases { get; set; }
        public DbSet<SheetGateValveCaseTCP> SheetGateValveCaseTCPs { get; set; }
        public DbSet<SheetGateValveCaseJournal> SheetGateValveCaseJournals { get; set; }

        public DbSet<CompactGateValveCase> CompactGateValveCases { get; set; }
        public DbSet<CompactGateValveCaseTCP> CompactGateValveCaseTCPs { get; set; }
        public DbSet<CompactGateValveCaseJournal> CompactGateValveCaseJournals { get; set; }

        public DbSet<Shutter> Shutters { get; set; }
        public DbSet<ShutterTCP> ShutterTCPs { get; set; }
        public DbSet<ShutterJournal> ShutterJournals { get; set; }

        public DbSet<ShutterDisk> ShutterDisks { get; set; }
        public DbSet<ShutterDiskTCP> ShutterDiskTCPs { get; set; }
        public DbSet<ShutterDiskJournal> ShutterDiskJournals { get; set; }

        public DbSet<ShutterGuide> ShutterGuides { get; set; }
        public DbSet<ShutterGuideTCP> ShutterGuideTCPs { get; set; }
        public DbSet<ShutterGuideJournal> ShutterGuideJournals { get; set; }

        public DbSet<FrontalSaddleSealing> FrontalSaddleSeals { get; set; }
        public DbSet<FrontalSaddleSealingTCP> FrontalSaddleSealingTCPs { get; set; }
        public DbSet<FrontalSaddleSealingJournal> FrontalSaddleSealingJournals { get; set; }
        public DbSet<SaddleWithSealing> SaddleWithSeals { get; set; }

        public DbSet<AssemblyUnitSealing> AssemblyUnitSeals{ get; set; }
        public DbSet<AssemblyUnitSealingTCP> AssemblyUnitSealingTCPs{ get; set; }
        public DbSet<AssemblyUnitSealingJournal> AssemblyUnitSealingJournals { get; set; }
        public DbSet<BaseValveWithSealing> BaseValveWithSeals { get; set; }

        public DbSet<ScrewStud> ScrewStuds { get; set; }
        public DbSet<ScrewStudTCP> ScrewStudTCPs { get; set; }
        public DbSet<ScrewStudJournal> ScrewStudJournals { get; set; }
        public DbSet<BaseValveWithScrewStud> BaseValveWithScrewStuds { get; set; }

        public DbSet<ScrewNut> ScrewNuts { get; set; }
        public DbSet<ScrewNutTCP> ScrewNutTCPs { get; set; }
        public DbSet<ScrewNutJournal> ScrewNutJournals { get; set; }
        public DbSet<BaseValveWithScrewNut> BaseValveWithScrewNuts { get; set; }

        public DbSet<Spring> Springs { get; set; }
        public DbSet<SpringTCP> SpringTCPs { get; set; }
        public DbSet<SpringJournal> SpringJournals { get; set; }
        public DbSet<BaseValveWithSpring> BaseValveWithSprings { get; set; }

        public DbSet<ShearPin> ShearPins { get; set; }
        public DbSet<ShearPinTCP> ShearPinTCPs { get; set; }
        public DbSet<ShearPinJournal> ShearPinJournals { get; set; }

        public DbSet<CounterFlange> CounterFlanges { get; set; }
        public DbSet<CounterFlangeTCP> CounterFlangeTCPs { get; set; }
        public DbSet<CounterFlangeJournal> CounterFlangeJournals { get; set; }

        public DbSet<BallValve> BallValves { get; set; }
        public DbSet<BallValveTCP> BallValveTCPs { get; set; }
        public DbSet<BallValveJournal> BallValveJournals{ get; set; }

        public DbSet<MetalMaterial> MetalMaterials { get; set; }
        public DbSet<MetalMaterialTCP> MetalMaterialTCPs { get; set; }

        public DbSet<SheetMaterial> SheetMaterials { get; set; }
        public DbSet<SheetMaterialJournal> SheetMaterialJournals { get; set; }

        public DbSet<ForgingMaterial> ForgingMaterials { get; set; }
        public DbSet<ForgingMaterialJournal> ForgingMaterialJournals { get; set; }

        public DbSet<RolledMaterial> RolledMaterials { get; set; }
        public DbSet<RolledMaterialJournal> RolledMaterialJournals { get; set; }

        public DbSet<PipeMaterial> PipeMaterials { get; set; }
        public DbSet<PipeMaterialJournal> PipeMaterialJournals { get; set; }

        public DbSet<BaseAnticorrosiveCoating> BaseAnticorrosiveCoatings { get; set; }
        public DbSet<AnticorrosiveCoatingTCP> AnticorrosiveCoatingTCPs { get; set; }

        public DbSet<AbovegroundCoating> AbovegroundCoatings { get; set; }
        public DbSet<AbovegroundCoatingJournal> AbovegroundCoatingJournals { get; set; }

        public DbSet<AbrasiveMaterial> AbrasiveMaterials { get; set; }
        public DbSet<AbrasiveMaterialJournal> AbrasiveMaterialJournals { get; set; }

        public DbSet<Undercoat> Undercoats { get; set; }
        public DbSet<UndercoatJournal> UndercoatJournals { get; set; }

        public DbSet<UndergroundCoating> UndergroundCoatings { get; set; }
        public DbSet<UndergroundCoatingJournal> UndergroundCoatingJournals { get; set; }

        public DbSet<WeldingMaterial> WeldingMaterials { get; set; }
        public DbSet<WeldingMaterialTCP> WeldingMaterialTCPs { get; set; }
        public DbSet<WeldingMaterialJournal> WeldingMaterialJournals { get; set; }

        public DbSet<ElectronicDocument> ElectronicDocuments { get; set; }
        public DbSet<SpecificationWithFile> SpecificationWithFiles { get; set; }
        public DbSet<BaseAssemblyUnitWithFile> BaseAssemblyUnitWithFiles { get; set; }
        public DbSet<BaseCastingCaseWithFile> BaseCastingCaseWithFiles { get; set; }
        public DbSet<AssemblyUnitSealsWithFile> AssemblyUnitSealsWithFiles { get; set; }
        public DbSet<BallValvesWithFile> BallValvesWithFiles { get; set; }
        public DbSet<BaseAnticorrosiveCoatingWithFile> BaseAnticorrosiveCoatingWithFiles { get; set; }
        public DbSet<BaseValveCoverWithFile> BaseValveCoverWithFiles { get; set; }
        public DbSet<BronzeSleeveShutterWithFile> BronzeSleeveShutterWithFiles { get; set; }
        public DbSet<CaseBottomWithFile> CaseBottomWithFiles { get; set; }
        public DbSet<CaseEdgeWithFile> CaseEdgeWithFiles { get; set; }
        public DbSet<CaseFlangeWithFile> CaseFlangeWithFiles { get; set; }
        public DbSet<ControlWeldWithFile> ControlWeldWithFiles { get; set; }
        public DbSet<CounterFlangeWithFile> CounterFlangeWithFiles { get; set; }
        public DbSet<CoverFlangeWithFile> CoverFlangeWithFiles { get; set; }
        public DbSet<CoverSealingRingWithFile> CoverSealingRingWithFiles { get; set; }
        public DbSet<CoverSleeveWithFile> CoverSleeveWithFiles { get; set; }
        public DbSet<FrontalSaddleSealingWithFile> FrontalSaddleSealingWithFiles { get; set; }
        public DbSet<FrontWallWithFile> FrontWallWithFiles { get; set; }
        public DbSet<GateWithFile> GateWithFiles { get; set; }
        public DbSet<MetalMaterialWithFile> MetalMaterialWithFiles { get; set; }
        public DbSet<NozzleWithFile> NozzleWithFiles { get; set; }
        public DbSet<PIDWithFile> PIDWithFiles { get; set; }
        public DbSet<RunningSleeveWithFile> RunningSleeveWithFiles { get; set; }
        public DbSet<SaddleWithFile> SaddleWithFiles { get; set; }
        public DbSet<ScrewNutWithFile> ScrewNutWithFiles { get; set; }
        public DbSet<ScrewStudWithFile> ScrewStudWithFiles { get; set; }
        public DbSet<ShaftShutterWithFile> ShaftShutterWithFiles { get; set; }
        public DbSet<ShearPinWithFile> ShearPinWithFiles { get; set; }
        public DbSet<ShutterDiskWithFile> ShutterDiskWithFiles { get; set; }
        public DbSet<ShutterGuideWithFile> ShutterGuideWithFiles { get; set; }
        public DbSet<ShutterWithFile> ShutterWithFiles { get; set; }
        public DbSet<SideWallWithFile> SideWallWithFiles { get; set; }
        public DbSet<SlamShutterWithFile> SlamShutterWithFiles { get; set; }
        public DbSet<SpindleWithFile> SpindleWithFiles { get; set; }
        public DbSet<SpringWithFile> SpringWithFiles { get; set; }
        public DbSet<SteelSleeveShutterWithFile> SteelSleeveShutterWithFiles { get; set; }
        public DbSet<StubShutterWithFile> StubShutterWithFiles { get; set; }
        public DbSet<WeldGateValveCaseWithFile> WeldGateValveCaseWithFiles { get; set; }
        public DbSet<WeldingMaterialWithFile> WeldingMaterialWithFiles { get; set; }
        public DbSet<WeldNozzleWithFile> WeldNozzleWithFiles { get; set; }

        //TODO: Не забываем добавлять все таблицы

        public DesktopDataContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationType>().HasData(new OperationType[]
                {
                new OperationType { Id=1, Name="Входной контроль"},
                new OperationType { Id=2, Name="Механическая обработка"},
                new OperationType { Id=3, Name="Неразрушающий контроль"},
                new OperationType { Id=4, Name="Сборка"},
                new OperationType { Id=5, Name="ПСИ"},
                new OperationType { Id=6, Name="ВИК после ПСИ"},
                new OperationType { Id=7, Name="АКП"},
                new OperationType { Id=8, Name="Документация"},
                new OperationType { Id=9, Name="Отгрузка"},
                new OperationType { Id=10, Name="Входной контроль (НК)"},
                new OperationType { Id=11, Name="Сборка/Сварка"},
                new OperationType { Id=12, Name="Подготовка к сборке"},
                new OperationType { Id=13, Name="Наплавка"},
                new OperationType { Id=14, Name="Подготовка поверхности"},
                new OperationType { Id=15, Name="Покрытие"}
                });
        }

            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlite("Filename=SupervisionData.sqlite", options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            //optionsBuilder.UseSqlite(@"Filename = O:\38-00 - Челябинское УТН\38-04 - СМТО\Производство\БД\SupervisionData\SupervisionData.sqlite", options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
#else
            //optionsBuilder.UseSqlite(@"Filename = T:\06-01-06 - БДУКП\СМТО ОП УТН\SupervisionData\Supervision\SupervisionData.sqlite", options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            optionsBuilder.UseSqlite($@"Filename = {Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\SupervisionData.sqlite", options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            //optionsBuilder.UseSqlite(@"Filename = O:\38-00 - Челябинское УТН\38-04 - СМТО\Производство\БД\SupervisionTest (Челябинск)\SupervisionData.sqlite", options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));

#endif
            base.OnConfiguring(optionsBuilder);
        }
    }
}
