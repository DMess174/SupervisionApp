using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using BusinessLayer.Repository.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class RunningSleeveRepository : RepositoryWithJournal<RunningSleeve, RunningSleeveJournal, RunningSleeveTCP>
    {
        public RunningSleeveRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(BaseValveCover cover)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.RunningSleeves.Include(i => i.BaseValveCover).SingleOrDefaultAsync(i => i.Id == cover.RunningSleeve.Id);
                if (detail?.BaseValveCover != null && detail.BaseValveCover.Id != cover.Id)
                {
                    MessageBox.Show($"Втулка ходовая применена в {detail.BaseValveCover.Name} № {detail.BaseValveCover.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public async Task<RunningSleeve> GetByIdIncludeAsync(int id)
        {
            var result = await db.RunningSleeves
                .Include(i => i.BaseValveCover)
                .Include(i => i.RunningSleeveJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
