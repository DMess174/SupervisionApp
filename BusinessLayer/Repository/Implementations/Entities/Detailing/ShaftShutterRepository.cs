using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class ShaftShutterRepository : RepositoryWithJournal<ShaftShutter, ShaftShutterJournal, ShaftShutterTCP>
    {
        public ShaftShutterRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(ReverseShutter shutter)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.ShaftShutters.Include(i => i.ReverseShutter).SingleOrDefaultAsync(i => i.Id == shutter.ShaftShutter.Id);
                if (detail?.ReverseShutter != null && detail.ReverseShutter.Id != shutter.Id)
                {
                    MessageBox.Show($"Ось применена в {detail.ReverseShutter.Name} № {detail.ReverseShutter.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<ShaftShutter>> GetAllAsync()
        {
            await db.ShaftShutters.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.ShaftShutters.Local.ToObservableCollection();
            return result;
        }

        public async Task<ShaftShutter> GetByIdIncludeAsync(int id)
        {
            var result = await db.ShaftShutters
                .Include(i => i.ReverseShutter)
                .Include(i => i.MetalMaterial)
                .Include(i => i.ShaftShutterJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.ShaftShutterJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
