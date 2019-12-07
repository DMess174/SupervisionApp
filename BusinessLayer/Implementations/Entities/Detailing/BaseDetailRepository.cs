using BusinessLayer.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations.Entities.Detailing
{
    public class BaseDetailRepository : Repository<BaseEntity>, IBaseDetailRepository<BaseJournal<BaseEntity, BaseTCP>, BaseTCP>
    {
        public BaseDetailRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;

        public async Task<IEnumerable<BaseJournal<BaseEntity, BaseTCP>>> GetJournal(int id)
        {
            return await Context.Set<BaseJournal<BaseEntity, BaseTCP>>().Where(i => i.DetailId == id).ToListAsync();
        }
    }
}
