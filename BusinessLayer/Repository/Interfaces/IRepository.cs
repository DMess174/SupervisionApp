using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces
{
    public interface IRepository<TEntity> 
    {
        int Add(TEntity entity);
        int Add(IEnumerable<TEntity> entities);
        Task<int> AddAsync(TEntity entity);
        Task<int> AddAsync(IEnumerable<TEntity> entities);

        int AddCopy(TEntity entity);
        Task<int> AddCopyAsync(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll<TEntitySortField>(Expression<Func<TEntity, TEntitySortField>> orderBy, bool ascending);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync<TEntitySortField>(Expression<Func<TEntity, TEntitySortField>> orderBy, bool ascending);

        TEntity GetById(int? id);

        int Update(TEntity entity);
        int Update(IEnumerable<TEntity> entities);

        int Delete(TEntity entity);

        IEnumerable<TEntity> GetSome(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetSomeAsync (Expression<Func<TEntity, bool>> where);
    }
}
