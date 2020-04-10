using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CompactGateValveCoverRepository : RepositoryWithJournal<CompactGateValveCover, CompactGateValveCoverJournal, CompactGateValveCoverTCP>
    {
        public CompactGateValveCoverRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(CompactGateValve valve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CompactGateValveCovers.Include(i => i.BaseWeldValve).SingleOrDefaultAsync(i => i.Id == valve.WeldGateValveCover.Id);
                if (detail?.BaseWeldValve != null && detail.BaseWeldValve.Id != valve.Id)
                {
                    MessageBox.Show($"Крышка применена в {detail.BaseWeldValve.Name} № {detail.BaseWeldValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public async Task<IList<CompactGateValveCover>> GetAllIncludeAsync()
        {
            await db.CompactGateValveCovers.Include(i => i.Spindle).LoadAsync();
            var result = db.CompactGateValveCovers.Local.ToObservableCollection();
            return result;
        }

        public override async Task<IList<CompactGateValveCover>> GetAllAsync()
        {
            await db.CompactGateValveCovers.LoadAsync();
            var result = db.CompactGateValveCovers.Local.ToObservableCollection();
            return result;
        }

        public async Task<CompactGateValveCover> GetByIdIncludeAsync(int id)
        {
            var result = await db.CompactGateValveCovers
                .Include(i => i.BaseWeldValve)
                .Include(i => i.RunningSleeve)
                .Include(i => i.CoverSleeve)
                .Include(i => i.CoverFlange)
                .Include(i => i.Spindle)
                .Include(i => i.CompactGateValveCoverJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.CompactGateValveCoverJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
