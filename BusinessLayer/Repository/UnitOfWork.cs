using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using BusinessLayer.Repository.Interfaces;
using BusinessLayer.Repository.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using Microsoft.EntityFrameworkCore.Storage;

namespace BusinessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        private readonly ConcurrentDictionary<Type, object> repositories;

        private IDbContextTransaction transaction;

        private bool disposed;

        public UnitOfWork(DataContext Context)
        {
            context = Context;
            repositories = new ConcurrentDictionary<Type, object>();

            Nozzle = new NozzleRepository(context);
        }

        public INozzleRepository Nozzle { get; private set; }

        public Task<int> CompleteAsync()
        {
            return context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (transaction == null) return;

            transaction.Commit();
            transaction.Dispose();

            transaction = null;
        }

        public IRepository<TEntity, TEntityJournal, TEntityTCP> GetRepository<TEntity, TEntityJournal, TEntityTCP>() 
            where TEntity : BaseTable
            where TEntityJournal : BaseJournal<TEntity, TEntityTCP>
            where TEntityTCP : BaseTCP
        {
            return repositories.GetOrAdd(typeof(TEntity), (object)new BusinessLayer.Repository.Implementations.Repository<TEntity, TEntityJournal, TEntityTCP>(context)) as IRepository<TEntity, TEntityJournal, TEntityTCP>;
        }

        public void RollbackTransaction()
        {
            if (transaction == null) return;

            transaction.Rollback();
            transaction.Dispose();

            transaction = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                context.Dispose();

            disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

    }
}
