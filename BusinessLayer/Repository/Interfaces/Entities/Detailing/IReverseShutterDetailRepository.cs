using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;

namespace BusinessLayer.Repository.Interfaces.Entities.Detailing
{
    public interface IReverseShutterDetailRepository<TEntity> : IRepository<ReverseShutterDetail>
        where  TEntity : ReverseShutterDetail
    {
    }
}
