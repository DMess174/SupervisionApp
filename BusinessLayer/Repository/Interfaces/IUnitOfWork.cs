using System;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;

namespace BusinessLayer.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        INozzleRepository Nozzle { get; }

        Task<int> CompleteAsync();
        void BeginTransaction();
        //void BeginTransaction(IsolationLevel level);
        void RollbackTransaction();
        void CommitTransaction();

        IRepository<TEntity, TEntityJournal, TEntityTCP> GetRepository<TEntity, TEntityJournal, TEntityTCP>()
            where TEntity : BaseTable
            where TEntityJournal : BaseJournal<TEntity, TEntityTCP>
            where TEntityTCP : BaseTCP;

    }
}
