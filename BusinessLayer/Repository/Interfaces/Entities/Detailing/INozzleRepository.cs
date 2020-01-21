using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace BusinessLayer.Repository.Interfaces.Entities.Detailing
{
    public interface INozzleRepository : IRepository<Nozzle>
    {
        Task<Nozzle> GetInclude(int id);

        Task<IEnumerable<NozzleJournal>> GetJournal(Nozzle nozzle);

        Task<IEnumerable<NozzleTCP>> GetPoints();
    }
}
