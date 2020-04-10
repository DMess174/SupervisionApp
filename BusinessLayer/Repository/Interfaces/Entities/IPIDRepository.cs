using DataLayer;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces.Entities
{
    public interface IPIDRepository : IRepositoryWithJournal<PID, PIDJournal, PIDTCP>
    {
        Task<PID> GetByIdIncludeAsync(int id);
    }
}
