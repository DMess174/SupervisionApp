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
    public class BronzeSleeveShutterRepository : RepositoryWithJournal<BronzeSleeveShutter, BronzeSleeveShutterJournal, BronzeSleeveShutterTCP>
    {
        public BronzeSleeveShutterRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(BronzeSleeveShutter sleeve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.BronzeSleeveShutters.Include(i => i.ReverseShutter).SingleOrDefaultAsync(i => i.Id == sleeve.Id);
                if (detail?.ReverseShutter != null)
                {
                    MessageBox.Show($"Втулка применена в {detail.ReverseShutter.Name} № {detail.ReverseShutter.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<BronzeSleeveShutter>> GetAllAsync()
        {
            await db.BronzeSleeveShutters.LoadAsync();
            var result = db.BronzeSleeveShutters.Local.ToObservableCollection();
            return result;
        }

        public async Task Load()
        {
            await db.BronzeSleeveShutters.LoadAsync();
        }

        public IList<BronzeSleeveShutter> UpdateList()
        {
            return db.BronzeSleeveShutters.Local.Where(i => i.ReverseShutterId == null).ToList();
        }

        public async Task<BronzeSleeveShutter> GetByIdIncludeAsync(int id)
        {
            var result = await db.BronzeSleeveShutters
                .Include(i => i.ReverseShutter)
                .Include(i => i.BronzeSleeveShutterJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
