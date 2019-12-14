using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;

namespace BusinessLayer.Repository.Interfaces
{
    public interface IRepository<TEntity, TEntityJournal, TEntityTCP> 
        where TEntity : BaseTable
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>
        where TEntityTCP : BaseTCP
    {
        Task<TEntity> EntityAddAsync(TEntity entity);
        Task<TEntityJournal> JournalAddAsync(TEntityJournal journal);
        Task<TEntityTCP> TCPAddAsync(TEntityTCP points);

        IEnumerable<TEntity> GetAllEntities();
        Task<IEnumerable<TEntity>> GetAllEntitiesAsync();
        TEntity GetById(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
