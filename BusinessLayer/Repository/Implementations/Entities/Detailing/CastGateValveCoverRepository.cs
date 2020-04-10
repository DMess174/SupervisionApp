using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CastGateValveCoverRepository : RepositoryWithJournal<CastGateValveCover, CastGateValveCoverJournal, CastGateValveCoverTCP>
    {
        public CastGateValveCoverRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(CastGateValve valve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CastGateValveCovers.Include(i => i.CastGateValve).SingleOrDefaultAsync(i => i.Id == valve.CastGateValveCover.Id);
                if (detail?.CastGateValve != null && detail.CastGateValve.Id != valve.Id)
                {
                    MessageBox.Show($"Крышка применена в {detail.CastGateValve.Name} № {detail.CastGateValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public async Task<IList<CastGateValveCover>> GetAllIncludeAsync()
        {
            await db.CastGateValveCovers.Include(i => i.Spindle).LoadAsync();
            var result = db.CastGateValveCovers.Local.ToObservableCollection();
            return result;
        }

        public override async Task<IList<CastGateValveCover>> GetAllAsync()
        {
            await db.CastGateValveCovers.LoadAsync();
            var result = db.CastGateValveCovers.Local.ToObservableCollection();
            return result;
        }

        public async Task<CastGateValveCover> GetByIdIncludeAsync(int id)
        {
            var result = await db.CastGateValveCovers
                .Include(i => i.CastGateValve)
                .Include(i => i.Spindle)
                .Include(i => i.RunningSleeve)
                .Include(i => i.CoverSealingRing)
                .Include(i => i.CastGateValveCoverJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.CastGateValveCoverJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
