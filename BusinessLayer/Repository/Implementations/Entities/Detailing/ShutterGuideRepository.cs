using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.CompactGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class ShutterGuideRepository : RepositoryWithJournal<ShutterGuide, ShutterGuideJournal, ShutterGuideTCP>
    {
        public ShutterGuideRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(ShutterGuide disk)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.ShutterGuides.Include(i => i.Shutter).SingleOrDefaultAsync(i => i.Id == disk.Id);
                if (detail?.Shutter != null)
                {
                    MessageBox.Show($"Диск применен в {detail.Shutter.Name} № {detail.Shutter.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<ShutterGuide>> GetAllAsync()
        {
            await db.ShutterGuides.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.ShutterGuides.Local.ToObservableCollection();
            return result;
        }

        public async Task Load()
        {
            await db.ShutterGuides.LoadAsync();
        }

        public IList<ShutterGuide> UpdateList()
        {
            return db.ShutterGuides.Local.Where(i => i.ShutterId == null).ToList();
        }

        public async Task<ShutterGuide> GetByIdIncludeAsync(int id)
        {
            var result = await db.ShutterGuides
                .Include(i => i.Shutter)
                .Include(i => i.ShutterGuideJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
