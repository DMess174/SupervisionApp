using DataLayer;
using DataLayer.Entities.Periodical;
using DataLayer.Journals.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class NDTPeriodicalRepository : RepositoryWithJournal<NDTControl, NDTControlJournal, NDTControlTCP>
    {
        public NDTPeriodicalRepository(DataContext context) : base(context) { }

        public override async Task<IList<NDTControl>> GetAllAsync()
        {
            await db.NDTControls.Include(i => i.ProductType).LoadAsync();
            return db.NDTControls.Local.ToObservableCollection();
        }

        public async Task<NDTControl> GetByIdIncludeAsync(int id)
        {
            return await db.NDTControls.Include(i => i.NDTControlJournals).SingleOrDefaultAsync(i => i.Id == id);
        }

        public void SetLastControlDate(NDTControl control)
        {
            var date = Convert.ToDateTime(control.NDTControlJournals.Where(i => i.DetailId == control.Id).Select(i => i.Date).Max());
            control.LastControl = date;
            control.NextControl = date.AddDays(7);
        }
    }
}
