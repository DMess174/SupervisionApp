using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Journals.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class ShutterRepository : RepositoryWithJournal<Shutter, ShutterJournal, ShutterTCP>
    {
        public ShutterRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(BaseValve valve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.Shutters.Include(i => i.BaseValve).SingleOrDefaultAsync(i => i.Id == valve.Shutter.Id);
                if (detail?.BaseValve != null && detail.BaseValve.Id != valve.Id)
                {
                    MessageBox.Show($"Затвор применен в {detail.BaseValve.Name} № {detail.BaseValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }



        public override async Task<IList<Shutter>> GetAllAsync()
        {
            await db.Shutters.LoadAsync();
            var result = db.Shutters.Local.ToObservableCollection();
            return result;
        }

        public async Task<Shutter> GetByIdIncludeAsync(int id)
        {
            var result = await db.Shutters
                .Include(i => i.BaseValve)
                .Include(i => i.ShutterDisks)
                .Include(i => i.ShutterGuides)
                .Include(i => i.ShutterJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
