using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;

namespace BusinessLayer.Repository.Interfaces.Entities.Detailing
{
    public interface IReverseShutterDetailRepository<TEntity, TEntityJournal, TEntityTCP> : IRepository<ReverseShutterDetail, BaseJournal<ReverseShutterDetail, BaseTCP>, BaseTCP>
        where  TEntity : ReverseShutterDetail
        where TEntityJournal : BaseJournal<ReverseShutterDetail, TEntityTCP>
        where TEntityTCP : BaseTCP
    {
        Task<IEnumerable<TEntityJournal>> GetJournal(int id);
    }
}
