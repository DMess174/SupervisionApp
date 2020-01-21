using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces
{
    public interface IRepositoryWithJournal<TEntity, TEntityJournal, TEntityTCP> : IRepository<TEntity> 
    {
        int AddJournalRecord(TEntity entity, TEntityJournal record);
        int AddJournalRecord(TEntity entity, IEnumerable<TEntityJournal> records);
        Task<int> AddJournalRecordAsync(TEntity entity, TEntityJournal record);
        Task<int> AddJournalRecordAsync(TEntity entity, IEnumerable<TEntityJournal> records);

        int AddCopyJournalRecord(TEntity entity, TEntityJournal record);
        Task<int> AddCopyJournalRecordAsync(TEntity entity, TEntityJournal record);

        int UpdateJournalRecord(TEntityJournal record);
        int UpdateJournalRecord(IEnumerable<TEntityJournal> records);

        int DeleteJournalRecord(TEntityJournal record);

        IEnumerable<TEntityJournal> GetSomeJournalRecord(Expression<Func<TEntityJournal, bool>> where);
        Task<IEnumerable<TEntityJournal>> GetSomeJournalRecordAsync(Expression<Func<TEntityJournal, bool>> where);
    }
}
