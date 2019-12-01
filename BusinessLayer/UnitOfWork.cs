    using BusinessLayer.Implementations.Entities;
using BusinessLayer.Implementations.Entities.Detailing;
using BusinessLayer.Implementations.Entities.AssemblyUnits;
using BusinessLayer.Interfaces;
using BusinessLayer.Interfaces.Entities;
using BusinessLayer.Interfaces.Entities.AssemblyUnits;
using BusinessLayer.Interfaces.Entities.Detailing;
using DataLayer;
using BusinessLayer.Interfaces.Journals.AssemblyUnits;
using BusinessLayer.Interfaces.TechnicalControlPlans.AssemblyUnits;
using BusinessLayer.Interfaces.Journals.Detailing;
using BusinessLayer.Interfaces.TechnicalControlPlans.Detailing;
using BusinessLayer.Implementations.Journals.Detailing;
using BusinessLayer.Implementations.Journals.AssemblyUnits;
using BusinessLayer.Implementations.TechnicalControlPlans.AssemblyUnits;
using BusinessLayer.Implementations.TechnicalControlPlans.Detailing;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.TechnicalControlPlans;
using DataLayer.Journals;

namespace BusinessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext Context;

        public UnitOfWork(DataContext context)
        {
            Context = context;

            BaseDetail = new BaseDetailRepository(Context);
            ShutterReverse = new ShutterReverseRepository(Context);
            ShutterReverseJournal = new ShutterReverseJournalRepository(Context);
            ShutterReverseTCP = new ShutterReverseTCPRepository(Context);

            BronzeSleeveShutter = new BronzeSleeveShutterRepository(Context);
            BronzeSleeveShutterJournal = new BronzeSleeveShutterJournalRepository(Context);
            BronzeSleeveShutterTCP = new BronzeSleeveShutterTCPRepository(Context);

            CaseShutter = new CaseShutterRepository(Context);
            CaseShutterJournal = new CaseShutterJournalRepository(Context);
            CaseShutterTCP = new CaseShutterTCPRepository(Context);

            Nozzle = new NozzleRepository(Context);
            NozzleJournal = new NozzleJournalRepository(Context);
            NozzleTCP = new NozzleTCPRepository(Context);

            ShaftShutter = new ShaftShutterRepository(Context);
            ShaftShutterJournal = new ShaftShutterJournalRepository(Context);
            ShaftShutterTCP = new ShaftShutterTCPRepository(Context);

            SlamShutter = new SlamShutterRepository(Context);
            SlamShutterJournal = new SlamShutterJournalRepository(Context);
            SlamShutterTCP = new SlamShutterTCPRepository(Context);

            SteelSleeveShutter = new SteelSleeveShutterRepository(Context);
            SteelSleeveShutterJournal = new SteelSleeveShutterJournalRepository(Context);
            SteelSleeveShutterTCP = new SteelSleeveShutterTCPRepository(Context);

            StubShutter = new StubShutterRepository(Context);
            StubShutterJournal = new StubShutterJournalRepository(Context);
            StubShutterTCP = new StubShutterTCPRepository(Context);

            Customer = new CustomerRepository(Context);
            Inspector = new InspectorRepository(Context);
            PID = new PIDRepository(Context);
            ProductType = new ProductTypeRepository(Context);
            Specification = new SpecificationRepository(Context);
        }

        public IBaseDetailRepository<BaseJournal<BaseEntity, BaseTCP>, BaseTCP> BaseDetail { get; private set; }
        public IShutterReverseRepository ShutterReverse { get; private set; }
        public IShutterReverseJournalRepository ShutterReverseJournal { get; private set; }
        public IShutterReverseTCPRepository ShutterReverseTCP { get; private set; }

        public IBronzeSleeveShutterRepository BronzeSleeveShutter { get; private set; }
        public IBronzeSleeveShutterJournalRepository BronzeSleeveShutterJournal { get; private set; }
        public IBronzeSleeveShutterTCPRepository BronzeSleeveShutterTCP { get; private set; }

        public ICaseShutterRepository CaseShutter { get; private set; }
        public ICaseShutterJournalRepository CaseShutterJournal { get; private set; }
        public ICaseShutterTCPRepository CaseShutterTCP { get; private set; }

        public INozzleRepository Nozzle { get; private set; }
        public INozzleJournalRepository NozzleJournal { get; private set; }
        public INozzleTCPRepository NozzleTCP { get; private set; }

        public IShaftShutterRepository ShaftShutter { get; private set; }
        public IShaftShutterJournalRepository ShaftShutterJournal { get; private set; }
        public IShaftShutterTCPRepository ShaftShutterTCP { get; private set; }

        public ISlamShutterRepository SlamShutter { get; private set; }
        public ISlamShutterJournalRepository SlamShutterJournal { get; private set; }
        public ISlamShutterTCPRepository SlamShutterTCP { get; private set; }

        public ISteelSleeveShutterRepository SteelSleeveShutter { get; private set; }
        public ISteelSleeveShutterJournalRepository SteelSleeveShutterJournal { get; private set; }
        public ISteelSleeveShutterTCPRepository SteelSleeveShutterTCP { get; private set; }

        public IStubShutterRepository StubShutter { get; private set; }
        public IStubShutterJournalRepository StubShutterJournal { get; private set; }
        public IStubShutterTCPRepository StubShutterTCP { get; private set; }

        public ICustomerRepository Customer { get; private set; }
        public IInspectorRepository Inspector { get; private set; }
        public IPIDRepository PID { get; private set; }
        public IProductTypeRepository ProductType { get; private set; }
        public ISpecificationRepository Specification { get; private set; }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

    }
}
