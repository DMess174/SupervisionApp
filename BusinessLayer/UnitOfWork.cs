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
using DataLayer.Entities;
using DataLayer.TechnicalControlPlans;
using DataLayer.Journals;

namespace BusinessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;

        public UnitOfWork(DataContext context)
        {
            this.context = context;

            BaseDetail = new BaseDetailRepository(this.context);
            ShutterReverse = new ShutterReverseRepository(this.context);
            ShutterReverseJournal = new ShutterReverseJournalRepository(this.context);
            ShutterReverseTCP = new ShutterReverseTCPRepository(this.context);

            BronzeSleeveShutter = new BronzeSleeveShutterRepository(this.context);
            BronzeSleeveShutterJournal = new BronzeSleeveShutterJournalRepository(this.context);
            BronzeSleeveShutterTCP = new BronzeSleeveShutterTCPRepository(this.context);

            CaseShutter = new CaseShutterRepository(this.context);
            CaseShutterJournal = new CaseShutterJournalRepository(this.context);
            CaseShutterTCP = new CaseShutterTCPRepository(this.context);

            Nozzle = new NozzleRepository(this.context);
            NozzleJournal = new NozzleJournalRepository(this.context);
            NozzleTCP = new NozzleTCPRepository(this.context);

            ShaftShutter = new ShaftShutterRepository(this.context);
            ShaftShutterJournal = new ShaftShutterJournalRepository(this.context);
            ShaftShutterTCP = new ShaftShutterTCPRepository(this.context);

            SlamShutter = new SlamShutterRepository(this.context);
            SlamShutterJournal = new SlamShutterJournalRepository(this.context);
            SlamShutterTCP = new SlamShutterTCPRepository(this.context);

            SteelSleeveShutter = new SteelSleeveShutterRepository(this.context);
            SteelSleeveShutterJournal = new SteelSleeveShutterJournalRepository(this.context);
            SteelSleeveShutterTCP = new SteelSleeveShutterTCPRepository(this.context);

            StubShutter = new StubShutterRepository(this.context);
            StubShutterJournal = new StubShutterJournalRepository(this.context);
            StubShutterTCP = new StubShutterTCPRepository(this.context);

            Customer = new CustomerRepository(this.context);
            Inspector = new InspectorRepository(this.context);
            PID = new PIDRepository(this.context);
            ProductType = new ProductTypeRepository(this.context);
            Specification = new SpecificationRepository(this.context);
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
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
