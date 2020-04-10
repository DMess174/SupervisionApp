using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class StubShutterRepository : RepositoryWithJournal<StubShutter, StubShutterJournal, StubShutterTCP>
    {
        public StubShutterRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(StubShutter stub)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.StubShutters.Include(i => i.ReverseShutter).SingleOrDefaultAsync(i => i.Id == stub.Id);
                if (detail?.ReverseShutter != null)
                {
                    MessageBox.Show($"Заглушка применена в {detail.ReverseShutter.Name} № {detail.ReverseShutter.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<StubShutter>> GetAllAsync()
        {
            await db.StubShutters.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.StubShutters.Local.ToObservableCollection();
            return result;
        }

        public async Task Load()
        {
            await db.StubShutters.LoadAsync();
        }

        public IList<StubShutter> UpdateList()
        {
            return db.StubShutters.Local.Where(i => i.ReverseShutterId == null).ToList();
        }

        public async Task<StubShutter> GetByIdIncludeAsync(int id)
        {
            var result = await db.StubShutters
                .Include(i => i.ReverseShutter)
                .Include(i => i.StubShutterJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
