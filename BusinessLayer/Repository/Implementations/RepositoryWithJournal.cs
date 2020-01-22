using System;
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
    public class RepositoryWithJournal<TEntity, TEntityJournal, TEntityTCP> : Repository<TEntity>, IDisposable, IRepositoryWithJournal<TEntity, TEntityJournal, TEntityTCP>
        where TEntity : BaseTable, new()
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>, new()
        where TEntityTCP : BaseTCP, new()
    {
        protected readonly DbSet<TEntityJournal> journal;
        protected readonly DbSet<TEntityTCP> tcp;

        public RepositoryWithJournal(DataContext context) : base(context)
        {
            journal = db.Set<TEntityJournal>();
            tcp = db.Set<TEntityTCP>();
        }

        public virtual int AddJournalRecord(TEntity entity, TEntityJournal record)
        {
            journal.Add(record);
            return SaveChanges();
        }

        public virtual int AddJournalRecord(TEntity entity, IEnumerable<TEntityJournal> entities)
        {
            journal.AddRange(entities);
            return SaveChanges();
        }

        public virtual async Task<int> AddJournalRecordAsync(TEntity entity, TEntityJournal record)
        {
            await journal.AddAsync(record);
            return SaveChanges();
        }

        public virtual int AddCopyJournalRecord(TEntity entity, TEntityJournal record)
        {
            TEntityJournal newEntity = new TEntityJournal();
            journal.Add(newEntity);
            return SaveChanges();
        }

        public virtual async Task<int> AddCopyJournalRecordAsync(TEntity entity, TEntityJournal record)
        {
            TEntityJournal newEntity = new TEntityJournal();
            await journal.AddAsync(newEntity);
            return SaveChanges();
        }

        public virtual async Task<int> AddJournalRecordAsync(TEntity entity, IEnumerable<TEntityJournal> entities)
        {
            await journal.AddRangeAsync(entities);
            return SaveChanges();
        }

        public int UpdateJournalRecord(TEntityJournal entity)
        {
            journal.Update(entity);
            return SaveChanges();
        }

        public int UpdateJournalRecord(IEnumerable<TEntityJournal> records)
        {
            journal.UpdateRange(records);
            return SaveChanges();
        }

        public int DeleteJournalRecord(TEntityJournal record)
        {
            db.Entry(record).State = EntityState.Deleted;
            return SaveChanges();
        }

        public IEnumerable<TEntityJournal> GetAllJournalRecords()
        {
            journal.Load();
            return journal.Local.ToObservableCollection();
        }

        public async Task<IEnumerable<TEntityJournal>> GetAllJournalRecordsAsync()
        {
            await journal.LoadAsync();
            return journal.Local.ToObservableCollection();
        }

        public IEnumerable<TEntityJournal> GetSomeJournalRecords(Expression<Func<TEntityJournal, bool>> where)
        {
            journal.Where(where).Load();
            return journal.Local.ToObservableCollection();
        }

        public async Task<IEnumerable<TEntityJournal>> GetSomeJournalRecordsAsync(Expression<Func<TEntityJournal, bool>> where)
        {
            await journal.Where(where).LoadAsync();
            return journal.Local.ToObservableCollection();
        }
    }
}