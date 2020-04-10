using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CounterFlangeRepository : RepositoryWithJournal<CounterFlange, CounterFlangeJournal, CounterFlangeTCP>
    {
        public CounterFlangeRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(CounterFlange flange)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CounterFlanges.Include(i => i.BaseValve).SingleOrDefaultAsync(i => i.Id == flange.Id);
                if (detail?.BaseValve != null)
                {
                    MessageBox.Show($"Фланец применен в {detail.BaseValve.Name} № {detail.BaseValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<CounterFlange>> GetAllAsync()
        {
            await db.CounterFlanges.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.CounterFlanges.Local.ToObservableCollection();
            return result;
        }

        public async Task Load()
        {
            await db.CounterFlanges.LoadAsync();
        }

        public IList<CounterFlange> UpdateList()
        {
            return db.CounterFlanges.Local.Where(i => i.BaseValveId == null).ToList();
        }

        public async Task<CounterFlange> GetByIdIncludeAsync(int id)
        {
            var result = await db.CounterFlanges
                .Include(i => i.BaseValve)
                .Include(i => i.CounterFlangeJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
