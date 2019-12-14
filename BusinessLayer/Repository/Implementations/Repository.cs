using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interfaces;
using DataLayer;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations
{
    public class Repository<TEntity, TEntityJournal, TEntityTCP> : IRepository<TEntity, TEntityJournal, TEntityTCP> 
        where TEntity : BaseTable
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>
        where TEntityTCP : BaseTCP
    {
        protected readonly DataContext context;

        protected DbSet<TEntity> DbEntity { get; set; }
        protected DbSet<TEntityJournal> DbJournal { get; set; }
        protected DbSet<TEntityTCP> DbTCP { get; set; }


        public Repository(DataContext Сontext)
        {
            context = Сontext;
            DbEntity = context.Set<TEntity>();
            DbJournal = context.Set<TEntityJournal>();
            DbTCP = context.Set<TEntityTCP>();
        }

        public async Task<TEntity> EntityAddAsync(TEntity entity)
        {
            var entry = await DbEntity.AddAsync(entity);
            return entry.Entity;
        }

        public async Task<TEntityJournal> JournalAddAsync(TEntityJournal journal)
        {
            var entry = await DbJournal.AddAsync(journal);
            return entry.Entity;
        }

        public async Task<TEntityTCP> TCPAddAsync(TEntityTCP point)
        {
            var entry = await DbTCP.AddAsync(point);
            return entry.Entity;
        }

        public virtual IEnumerable<TEntity> GetAllEntities()
        {
            DbEntity.Load();
            return DbEntity.Local.ToObservableCollection();
        }
        //identity
        public async Task<IEnumerable<TEntity>> GetAllEntitiesAsync()
        {
            await DbEntity.LoadAsync();
            return DbEntity.Local.ToObservableCollection();
        }

        public virtual TEntity GetById(int id)
        {
            return DbEntity.FirstOrDefault(e => e.Id == id);
        }

        public void Update(TEntity entity)
        {
            DbEntity.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            DbEntity.Remove(entity);
        }
    }
}