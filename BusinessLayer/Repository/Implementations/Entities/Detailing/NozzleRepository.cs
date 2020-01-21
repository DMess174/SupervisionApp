using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class NozzleRepository : Repository<Nozzle>, INozzleRepository
    {
        public NozzleRepository(DataContext context) : base(context)
        {
        }

        public Task<Nozzle> GetInclude(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<NozzleJournal>> GetJournal(Nozzle nozzle)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<NozzleTCP>> GetPoints()
        {
            throw new System.NotImplementedException();
        }
    }
}
