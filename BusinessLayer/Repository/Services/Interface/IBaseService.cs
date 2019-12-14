using System.Threading.Tasks;
using DataLayer;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;

namespace BusinessLayer.Repository.Services.Interface
{
    public interface IBaseService<TEntity, TEntityJournal, TEntityTCP>
        where TEntity : BaseTable
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>
        where TEntityTCP : BaseTCP
    {
        Task<QueryResult<TEntity>> CreateItemAsync();
        Task<QueryResult<TEntity>> EditItemAsync(TEntity edit);
        Task<QueryResult<TEntity>> DeleteItemAsync(TEntity delete);

        Task<QueryResult<TEntityJournal>> CreateJournalAsync(TEntity added);

    }
}