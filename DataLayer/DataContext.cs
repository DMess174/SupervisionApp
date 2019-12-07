using Microsoft.EntityFrameworkCore;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using System.Reflection;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DataLayer.TechnicalControlPlans.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.Journals;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

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
