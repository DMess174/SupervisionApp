using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using BusinessLayer.Repository.Interfaces;
using DataLayer;
using DataLayer.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BusinessLayer.Repository.Implementations
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity>
        where TEntity : BaseTable, new()
    {
        protected DataContext db;
        protected readonly DbSet<TEntity> table;
        protected readonly DbSet<Inspector> inspector;
        protected readonly DbSet<MetalMaterial> metalMaterials;


        public Repository() : this(new DataContext())
        {
        }

        public Repository(DataContext context)
        {
            db = context;
            table = db.Set<TEntity>();
            inspector = db.Set<Inspector>();
            metalMaterials = db.Set<MetalMaterial>();
        }

        public void Dispose()
        {
            db?.Dispose();
        }


        public async Task<IEnumerable<Inspector>> GetInspectorsAsync()
        {
            return await inspector.ToListAsync();
        }

        public async Task<IEnumerable<MetalMaterial>> GetMaterialsAsync()
        {
            return await metalMaterials.ToListAsync();
        }

        public virtual TEntity Add(TEntity entity)
        {
            table.Add(entity);
            SaveChanges();
            return entity;
        }

        public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            table.AddRange(entities);
            SaveChanges();
            return entities;
        }

        public virtual TEntity AddCopy(TEntity entity)
        {
            TEntity newEntity = new TEntity();
            table.Add(newEntity);
            SaveChanges();
            return newEntity;
        }

        public virtual async Task<TEntity> AddCopyAsync(TEntity entity)
        {
            TEntity newEntity = new TEntity();
            await table.AddAsync(newEntity);
            await SaveChangesAsync();
            return newEntity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await table.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities)
        {
            await table.AddRangeAsync(entities);
            await SaveChangesAsync();
            return entities;
        }

        public IEnumerable<TEntity> GetAll()
        {
            table.Load();
            return table.Local.ToObservableCollection();
        }

        public virtual IEnumerable<TEntity> GetAll<TEntitySortField>(Expression<Func<TEntity, TEntitySortField>> orderBy, bool ascending)
        {
            (ascending ? table.OrderBy(orderBy) : table.OrderByDescending(orderBy)).Load();
            return table.Local.ToObservableCollection();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            await table.LoadAsync();
            return table.Local.ToObservableCollection();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntitySortField>(Expression<Func<TEntity, TEntitySortField>> orderBy, bool ascending)
        {
            await (ascending ? table.OrderBy(orderBy) : table.OrderByDescending(orderBy)).LoadAsync();
            return table.Local.ToObservableCollection();
        }

        public TEntity GetById(int? id) => table.Find(id);
        public async Task<TEntity> GetByIdAsync(int? id) => await table.FindAsync(id);

        public int Update(TEntity entity)
        {
            table.Update(entity);
            return SaveChanges();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            table.Update(entity);
            return await SaveChangesAsync();
        }

        public int Update(IEnumerable<TEntity> entities)
        {
            table.UpdateRange(entities);
            return SaveChanges();
        }

        public async Task<int> UpdateAsync(IEnumerable<TEntity> entities)
        {
            table.UpdateRange(entities);
            return await SaveChangesAsync();
        }

        public int Delete(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public IEnumerable<TEntity> GetSome(Expression<Func<TEntity, bool>> where)
        {
            table.Where(where).Load();
            return table.Local.ToObservableCollection();
        }

        public virtual async Task<IList<TEntity>> GetSomeAsync (Expression<Func<TEntity, bool>> where)
        {
            await table.Where(where).LoadAsync();
            return table.Local.ToObservableCollection();
        }

        public async Task<int> RemoveAsync(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> GetPropertyValuesDistinctAsync (Expression<Func<TEntity, string>> select)
        {
            return await db.Set<TEntity>().Select(select).Distinct().ToListAsync();
        }

        public bool HasChanges(TEntity entity)
        {
            return db.Entry(entity).State == EntityState.Modified;
        }

        public bool HasChanges(IEnumerable<TEntity> entities)
        {
            foreach (var i in entities)
            {
                var result = db.Entry(i).State == EntityState.Modified;
                if (result)
                    return result;
            }
            return false;
        }

        internal int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            catch (RetryLimitExceededException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            catch (RetryLimitExceededException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}