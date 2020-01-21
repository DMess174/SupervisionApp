﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interfaces;
using DataLayer;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BusinessLayer.Repository.Implementations
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity>
        where TEntity : BaseTable, new()
    {
        protected readonly DataContext db;
        protected readonly DbSet<TEntity> table;
        protected DataContext Context => db;

        public Repository() : this(new DataContext())
        {
        }

        public Repository(DataContext context)
        {
            db = context;
            table = db.Set<TEntity>();
        }

        public void Dispose()
        {
            db?.Dispose();
        }


        public int Add(TEntity entity)
        {
            table.Add(entity);
            return SaveChanges();
        }

        public int Add(IEnumerable<TEntity> entities)
        {
            table.AddRange(entities);
            return SaveChanges();
        }

        public virtual int AddCopy(TEntity entity)
        {
            TEntity newEntity = new TEntity();
            table.Add(newEntity);
            return SaveChanges();
        }

        public virtual async Task<int> AddCopyAsync(TEntity entity)
        {
            TEntity newEntity = new TEntity();
            await table.AddAsync(newEntity);
            return SaveChanges();
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await table.AddAsync(entity);
            return SaveChanges();
        }

        public async Task<int> AddAsync(IEnumerable<TEntity> entities)
        {
            await table.AddRangeAsync(entities);
            return SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            table.Load();
            return table.Local.ToObservableCollection();
        }

        public IEnumerable<TEntity> GetAll<TEntitySortField>(Expression<Func<TEntity, TEntitySortField>> orderBy, bool ascending)
        {
            (ascending ? table.OrderBy(orderBy) : table.OrderByDescending(orderBy)).Load();
            return table.Local.ToObservableCollection();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
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

        public int Update(TEntity entity)
        {
            table.Update(entity);
            return SaveChanges();
        }

        public int Update(IEnumerable<TEntity> entities)
        {
            table.UpdateRange(entities);
            return SaveChanges();
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

        public async Task<IEnumerable<TEntity>> GetSomeAsync (Expression<Func<TEntity, bool>> where)
        {
            await table.Where(where).LoadAsync();
            return table.Local.ToObservableCollection();
        }

        internal int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw; //Заглушка
            }
            catch (RetryLimitExceededException ex)
            {
                throw; //Заглушка
            }
            catch (DbUpdateException ex)
            {
                throw; //Заглушка
            }
            catch (Exception ex)
            {
                throw; //Заглушка
            }
        }

        
    }
}