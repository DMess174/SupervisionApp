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
    public class CoverSleeveRepository : RepositoryWithJournal<CoverSleeve, CoverSleeveJournal, CoverSleeveTCP>
    {
        public CoverSleeveRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(WeldGateValveCover cover)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CoverSleeves.Include(i => i.WeldGateValveCover).SingleOrDefaultAsync(i => i.Id == cover.CoverSleeve.Id);
                if (detail?.WeldGateValveCover != null && detail.WeldGateValveCover.Id != cover.Id)
                {
                    MessageBox.Show($"Втулка крышки применена в {detail.WeldGateValveCover.Name} № {detail.WeldGateValveCover.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<CoverSleeve>> GetAllAsync()
        {
            await db.CoverSleeves.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.CoverSleeves.Local.ToObservableCollection();
            return result;
        }

        public async Task<CoverSleeve> GetByIdIncludeAsync(int id)
        {
            var result = await db.CoverSleeves
                .Include(i => i.WeldGateValveCover)
                .Include(i => i.CoverSleeveJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .Include(i => i.CoverSealingRing)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
