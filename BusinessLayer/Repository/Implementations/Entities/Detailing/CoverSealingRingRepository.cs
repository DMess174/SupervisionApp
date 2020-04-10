using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CoverSealingRingRepository : RepositoryWithJournal<CoverSealingRing, CoverSealingRingJournal, CoverSealingRingTCP>
    {
        public CoverSealingRingRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedInSleeveAsync(CoverSleeve sleeve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CoverSealingRings.Include(i => i.CoverSleeve).Include(i => i.CastGateValveCover).SingleOrDefaultAsync(i => i.Id == sleeve.CoverSealingRingId);
                if ((detail?.CoverSleeve != null && detail?.CoverSleeve.Id != sleeve.Id) || detail?.CastGateValveCover != null)
                {
                    if (detail?.CoverSleeve != null) MessageBox.Show($"Кольцо уплотнительное применено в {detail.CoverSleeve.Name} № {detail.CoverSleeve.Number}", "Ошибка");
                    if (detail?.CastGateValveCover != null) MessageBox.Show($"Кольцо уплотнительное применено в {detail.CastGateValveCover.Name} № {detail.CastGateValveCover.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public async Task<bool> IsAssembliedInCoverAsync(CastGateValveCover cover)
        {
            var detail = await db.CoverSealingRings.Include(i => i.CastGateValveCover).Include(i => i.CoverSleeve).SingleOrDefaultAsync(i => i.Id == cover.CoverSealingRingId);
            if ((detail?.CastGateValveCover != null && detail.CastGateValveCover.Id != cover.Id) || detail.CoverSleeve != null)
            {
                if (detail?.CoverSleeve != null) MessageBox.Show($"Кольцо уплотнительное собрано с {detail.CoverSleeve.Name} № {detail.CoverSleeve.Number}", "Ошибка");
                if (detail?.CastGateValveCover != null) MessageBox.Show($"Кольцо уплотнительное собрано с {detail.CastGateValveCover.Name} № {detail.CastGateValveCover.Number}", "Ошибка");
                return true;
            }
            else return false;
        }

        public override async Task<IList<CoverSealingRing>> GetAllAsync()
        {
            await db.CoverSealingRings.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.CoverSealingRings.Local.ToObservableCollection();
            return result;
        }

        public async Task<CoverSealingRing> GetByIdIncludeAsync(int id)
        {
            var result = await db.CoverSealingRings
                .Include(i => i.CastGateValveCover)
                .Include(i => i.CoverSleeve)
                .Include(i => i.CoverSealingRingJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
