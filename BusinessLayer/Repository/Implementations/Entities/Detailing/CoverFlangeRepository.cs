using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CoverFlangeRepository : RepositoryWithJournal<CoverFlange, CoverFlangeJournal, CoverFlangeTCP>
    {
        public CoverFlangeRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(WeldGateValveCover cover)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CoverFlanges.Include(i => i.WeldGateValveCover).SingleOrDefaultAsync(i => i.Id == cover.CoverFlange.Id);
                if (detail?.WeldGateValveCover != null && detail.WeldGateValveCover.Id != cover.Id)
                {
                    MessageBox.Show($"Фланец применен в {detail.WeldGateValveCover.Name} № {detail.WeldGateValveCover.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<CoverFlange>> GetAllAsync()
        {
            await db.CoverFlanges.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.CoverFlanges.Local.ToObservableCollection();
            return result;
        }

        public async Task<CoverFlange> GetByIdIncludeAsync(int id)
        {
            var result = await db.CoverFlanges
                .Include(i => i.WeldGateValveCover)
                .Include(i => i.CoverFlangeJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
