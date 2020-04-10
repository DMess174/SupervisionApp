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
    public class ShutterDiskRepository : RepositoryWithJournal<ShutterDisk, ShutterDiskJournal, ShutterDiskTCP>
    {
        public ShutterDiskRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(ShutterDisk disk)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.ShutterDisks.Include(i => i.Shutter).SingleOrDefaultAsync(i => i.Id == disk.Id);
                if (detail?.Shutter != null)
                {
                    MessageBox.Show($"Диск применен в {detail.Shutter.Name} № {detail.Shutter.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<ShutterDisk>> GetAllAsync()
        {
            await db.ShutterDisks.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.ShutterDisks.Local.ToObservableCollection();
            return result;
        }

        public async Task Load()
        {
            await db.ShutterDisks.LoadAsync();
        }

        public IList<ShutterDisk> UpdateList()
        {
            return db.ShutterDisks.Local.Where(i => i.ShutterId == null).ToList();
        }

        public async Task<ShutterDisk> GetByIdIncludeAsync(int id)
        {
            var result = await db.ShutterDisks
                .Include(i => i.Shutter)
                .Include(i => i.ShutterDiskJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
