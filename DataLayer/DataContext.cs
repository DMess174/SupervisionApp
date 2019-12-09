using Microsoft.EntityFrameworkCore;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using System.Reflection;
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

namespace DataLayer
{
    public sealed class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Specification> Specifications{ get; set; }
        public DbSet<PID> PIDs { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }
        public DbSet<JournalNumber> JournalNumbers { get; set; }

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
        
        public DbSet<ReverseShutter> ShutterReverses { get; set; }
        public DbSet<ReverseShutterTCP> ReverseShutterTCPs { get; set; }
        public DbSet<ReverseShutterJournal> ReverseShutterJournals { get; set; }

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


        //TODO: Не забываем добавлять все таблицы

        public DataContext()
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SupervisionData.sqlite", options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
