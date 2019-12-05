using Microsoft.EntityFrameworkCore;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using System.Reflection;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DataLayer.TechnicalControlPlans.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.Journals;

namespace DataLayer
{
    public class DataContext : DbContext
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
        
        public DbSet<ShutterCase> CaseShutters { get; set; }
        public DbSet<CaseShutterTCP> CaseShutterTCPs{ get; set; }
        public DbSet<CaseShutterJournal> CaseShutterJournals{ get; set; }

        public DbSet<Nozzle> Nozzles { get; set; }
        public DbSet<NozzleTCP> NozzleTCPs { get; set; }
        public DbSet<NozzleJournal> NozzleJournals { get; set; }

        public DbSet<ShaftShutter> ShaftShutters { get; set; }
        public DbSet<ShaftShutterTCP> ShaftShutterTCPs { get; set; }
        public DbSet<ShaftShutterJournal> ShaftShutterJournals { get; set; }
        
        public DbSet<ShutterReverse> ShutterReverses { get; set; }
        public DbSet<ShutterReverseTCP> ShutterReverseTCPs { get; set; }
        public DbSet<ShutterReverseJournal> ShutterReverseJournals { get; set; }

        public DbSet<SlamShutter> SlamShutters { get; set; }
        public DbSet<SlamShutterTCP> SlamShutterTCPs { get; set; }
        public DbSet<SlamShutterJournal> SlamShutterJournals { get; set; }

        public DbSet<SteelSleeveShutter> SteelSleeveShutters { get; set; }
        public DbSet<SteelSleeveShutterTCP> SteelSleeveShutterTCPs { get; set; }
        public DbSet<SteelSleeveShutterJournal> SteelSleeveShutterJournals { get; set; }

        public DbSet<StubShutter> StubShutters { get; set; }
        public DbSet<StubShutterTCP> StubShutterTCPs { get; set; }
        public DbSet<StubShutterJournal> StubShutterJournals { get; set; }

        public DbSet<ValveCase> ValveCases { get; set; }
        public DbSet<ValveCaseTCP> ValveCaseTCPs { get; set; }
        public DbSet<ValveCaseJournal> ValveCaseJournals { get; set; }

        public DataContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SupervisionData.sqlite", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });


            base.OnConfiguring(optionsBuilder);
        }

    }
}
