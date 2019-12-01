using BusinessLayer.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Entities.Detailing;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations.Entities.Detailing
{
    public class BaseDetailRepository : Repository<BaseEntity>, IBaseDetailRepository<BaseJournal<BaseEntity, BaseTCP>, BaseTCP>
    {
        public BaseDetailRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }

        public async Task<IEnumerable<BaseJournal<BaseEntity, BaseTCP>>> GetJournal(int id)
        {
            return await Context.Set<BaseJournal<BaseEntity, BaseTCP>>().Where(i => i.DetailId == id).ToListAsync();
        }
    }
}
