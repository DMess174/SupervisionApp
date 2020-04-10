using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class SpindleRepository : RepositoryWithJournal<Spindle, SpindleJournal, SpindleTCP>
    {
        public SpindleRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(BaseValveCover cover)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.Spindles.Include(i => i.BaseValveCover).SingleOrDefaultAsync(i => i.Id == cover.Spindle.Id);
                if (detail?.BaseValveCover != null && detail.BaseValveCover.Id != cover.Id)
                {
                    MessageBox.Show($"Шпиндель применен в {detail.BaseValveCover.Name} № {detail.BaseValveCover.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<Spindle>> GetAllAsync()
        {
            await db.Spindles.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.Spindles.Local.ToObservableCollection();
            return result;
        }

        public async Task<Spindle> GetByIdIncludeAsync(int id)
        {
            var result = await db.Spindles
                .Include(i => i.BaseValveCover)
                .Include(i => i.SpindleJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
