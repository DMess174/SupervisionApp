using DataLayer;
using DataLayer.Entities.Periodical;
using DataLayer.Journals.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class WeldingPeriodicalRepository : RepositoryWithJournal<WeldingProcedures, WeldingProceduresJournal, WeldingProceduresTCP>
    {
        public WeldingPeriodicalRepository(DataContext context) : base(context) { }

        public override async Task<IList<WeldingProcedures>> GetAllAsync()
        {
            await db.WeldingProcedures.Include(i => i.ProductType).LoadAsync();
            return db.WeldingProcedures.Local.ToObservableCollection();
        }

        public async Task<WeldingProcedures> GetByIdIncludeAsync(int id)
        {
            return await db.WeldingProcedures.Include(i => i.WeldingProceduresJournals).SingleOrDefaultAsync(i => i.Id == id);
        }

        public void SetLastControlDate(WeldingProcedures control)
        {
            var date = Convert.ToDateTime(control.WeldingProceduresJournals.Where(i => i.DetailId == control.Id).Select(i => i.Date).Max());
            control.LastControl = date;
            control.NextControl = date.AddDays(7);
        }
    }
}
