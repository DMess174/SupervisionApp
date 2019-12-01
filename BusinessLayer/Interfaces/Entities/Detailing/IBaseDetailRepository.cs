using DataLayer.Entities;
using DataLayer.Entities.Detailing;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Entities.Detailing
{
    public interface IBaseDetailRepository<TJournal, TEntityTCP> : IRepository<BaseEntity>
        where TJournal : BaseJournal<BaseEntity, TEntityTCP>
        where TEntityTCP : BaseTCP
    {
        Task<IEnumerable<TJournal>> GetJournal(int id);
    }
}
