using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class SheetGateValveCoverRepository : RepositoryWithJournal<SheetGateValveCover, SheetGateValveCoverJournal, SheetGateValveCoverTCP>
    {
        public SheetGateValveCoverRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(SheetGateValve valve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.SheetGateValveCovers.Include(i => i.BaseWeldValve).SingleOrDefaultAsync(i => i.Id == valve.WeldGateValveCover.Id);
                if (detail?.BaseWeldValve != null && detail.BaseWeldValve.Id != valve.Id)
                {
                    MessageBox.Show($"Крышка применена в {detail.BaseWeldValve.Name} № {detail.BaseWeldValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public async Task<IList<SheetGateValveCover>> GetAllIncludeAsync()
        {
            await db.SheetGateValveCovers.Include(i => i.Spindle).LoadAsync();
            var result = db.SheetGateValveCovers.Local.ToObservableCollection();
            return result;
        }

        public override async Task<IList<SheetGateValveCover>> GetAllAsync()
        {
            await db.SheetGateValveCovers.LoadAsync();
            var result = db.SheetGateValveCovers.Local.ToObservableCollection();
            return result;
        }

        public async Task<SheetGateValveCover> GetByIdIncludeAsync(int id)
        {
            var result = await db.SheetGateValveCovers
                .Include(i => i.BaseWeldValve)
                .Include(i => i.RunningSleeve)
                .Include(i => i.CoverSleeve)
                .Include(i => i.CoverFlange)
                .Include(i => i.Spindle)
                .Include(i => i.SheetGateValveCoverJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.SheetGateValveCoverJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
