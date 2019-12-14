using BusinessLayer.Repository.Interfaces;
using DataLayer;

namespace BusinessLayer.Repository.Implementations
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDataContextFactory appDataContextFactory;

        public UnitOfWorkFactory(IDataContextFactory AppDataContextFactory)
        {
            appDataContextFactory = AppDataContextFactory;
        }

        public IUnitOfWork MakeUnitOfWork()
        {
            return new UnitOfWork(appDataContextFactory.Create());
        }
    }
}