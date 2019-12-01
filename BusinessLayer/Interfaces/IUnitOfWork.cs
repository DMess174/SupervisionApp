using BusinessLayer.Interfaces.Entities;
using BusinessLayer.Interfaces.Entities.AssemblyUnits;
using BusinessLayer.Interfaces.Entities.Detailing;
using BusinessLayer.Interfaces.Journals.AssemblyUnits;
using BusinessLayer.Interfaces.Journals.Detailing;
using BusinessLayer.Interfaces.TechnicalControlPlans.AssemblyUnits;
using BusinessLayer.Interfaces.TechnicalControlPlans.Detailing;
using DataLayer.Entities;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseDetailRepository<BaseJournal<BaseEntity, BaseTCP>, BaseTCP> BaseDetail { get; }
        IShutterReverseRepository ShutterReverse { get; }
        IShutterReverseJournalRepository ShutterReverseJournal { get; }
        IShutterReverseTCPRepository ShutterReverseTCP { get; }

        IBronzeSleeveShutterRepository BronzeSleeveShutter { get; }
        IBronzeSleeveShutterJournalRepository BronzeSleeveShutterJournal { get; }
        IBronzeSleeveShutterTCPRepository BronzeSleeveShutterTCP { get; }

        ICaseShutterRepository CaseShutter { get; }
        ICaseShutterJournalRepository CaseShutterJournal { get; }
        ICaseShutterTCPRepository CaseShutterTCP { get; }

        INozzleRepository Nozzle { get; }
        INozzleJournalRepository NozzleJournal { get; }
        INozzleTCPRepository NozzleTCP { get; }

        IShaftShutterRepository ShaftShutter { get; }
        IShaftShutterJournalRepository ShaftShutterJournal { get; }
        IShaftShutterTCPRepository ShaftShutterTCP { get; }

        ISlamShutterRepository SlamShutter { get; }
        ISlamShutterJournalRepository SlamShutterJournal { get; }
        ISlamShutterTCPRepository SlamShutterTCP { get; }

        ISteelSleeveShutterRepository SteelSleeveShutter { get; }
        ISteelSleeveShutterJournalRepository SteelSleeveShutterJournal { get; }
        ISteelSleeveShutterTCPRepository SteelSleeveShutterTCP { get; }

        IStubShutterRepository StubShutter { get; }
        IStubShutterJournalRepository StubShutterJournal { get; }
        IStubShutterTCPRepository StubShutterTCP { get; }

        ICustomerRepository Customer { get; }
        IInspectorRepository Inspector { get; }
        IPIDRepository PID { get; }
        IProductTypeRepository ProductType { get; }
        ISpecificationRepository Specification { get; }

        int Complete();
    }
}
