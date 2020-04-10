using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class BallValveRepository : RepositoryWithJournal<BallValve, BallValveJournal, BallValveTCP>
    {
        public BallValveRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(BallValve ballValve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.BallValves.Include(i => i.BaseValve).SingleOrDefaultAsync(i => i.Id == ballValve.Id);
                if (detail?.BaseValve != null)
                {
                    MessageBox.Show($"Кран шаровой применен в {detail.BaseValve.Name} № {detail.BaseValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<BallValve>> GetAllAsync()
        {
            await db.BallValves.LoadAsync();
            var result = db.BallValves.Local.ToObservableCollection();
            return result;
        }

        public async Task Load()
        {
            await db.BallValves.LoadAsync();
        }

        public IList<BallValve> UpdateList()
        {
            return db.BallValves.Local.Where(i => i.BaseValveId == null).ToList();
        }

        public async Task<BallValve> GetByIdIncludeAsync(int id)
        {
            var result = await db.BallValves
                .Include(i => i.BaseValve)
                .Include(i => i.BallValveJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
