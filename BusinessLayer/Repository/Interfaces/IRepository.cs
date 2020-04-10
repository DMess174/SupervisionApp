using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces
{
    public interface IRepository<TEntity> 
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities);

        TEntity AddCopy(TEntity entity);
        Task<TEntity> AddCopyAsync(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll<TEntitySortField>(Expression<Func<TEntity, TEntitySortField>> orderBy, bool ascending);

        Task<IList<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync<TEntitySortField>(Expression<Func<TEntity, TEntitySortField>> orderBy, bool ascending);

        TEntity GetById(int? id);
        Task<TEntity> GetByIdAsync(int? id);

        int Update(TEntity entity);
        int Update(IEnumerable<TEntity> entities);

        int Delete(TEntity entity);

        IEnumerable<TEntity> GetSome(Expression<Func<TEntity, bool>> where);
        Task<IList<TEntity>> GetSomeAsync (Expression<Func<TEntity, bool>> where);
    }
}
