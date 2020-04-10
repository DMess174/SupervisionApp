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
    public class SteelSleeveShutterRepository : RepositoryWithJournal<SteelSleeveShutter, SteelSleeveShutterJournal, SteelSleeveShutterTCP>
    {
        public SteelSleeveShutterRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(SteelSleeveShutter sleeve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.SteelSleeveShutters.Include(i => i.ReverseShutter).SingleOrDefaultAsync(i => i.Id == sleeve.Id);
                if (detail?.ReverseShutter != null)
                {
                    MessageBox.Show($"Втулка применена в {detail.ReverseShutter.Name} № {detail.ReverseShutter.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<SteelSleeveShutter>> GetAllAsync()
        {
            await db.SteelSleeveShutters.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.SteelSleeveShutters.Local.ToObservableCollection();
            return result;
        }

        public async Task Load()
        {
            await db.SteelSleeveShutters.LoadAsync();
        }

        public IList<SteelSleeveShutter> UpdateList()
        {
            return db.SteelSleeveShutters.Local.Where(i => i.ReverseShutterId == null).ToList();
        }

        public async Task<SteelSleeveShutter> GetByIdIncludeAsync(int id)
        {
            var result = await db.SteelSleeveShutters
                .Include(i => i.ReverseShutter)
                .Include(i => i.SteelSleeveShutterJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
