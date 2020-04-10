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
    public class SlamShutterRepository : RepositoryWithJournal<SlamShutter, SlamShutterJournal, SlamShutterTCP>
    {
        public SlamShutterRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(ReverseShutter shutter)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.SlamShutters.Include(i => i.ReverseShutter).SingleOrDefaultAsync(i => i.Id == shutter.SlamShutter.Id);
                if (detail?.ReverseShutter != null && detail.ReverseShutter.Id != shutter.Id)
                {
                    MessageBox.Show($"Захлопка применена в {detail.ReverseShutter.Name} № {detail.ReverseShutter.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<SlamShutter>> GetAllAsync()
        {
            await db.SlamShutters.LoadAsync();
            var result = db.SlamShutters.Local.ToObservableCollection();
            return result;
        }

        public async Task<SlamShutter> GetByIdIncludeAsync(int id)
        {
            var result = await db.SlamShutters
                .Include(i => i.ReverseShutter)
                .Include(i => i.SlamShutterJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.SlamShutterJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
