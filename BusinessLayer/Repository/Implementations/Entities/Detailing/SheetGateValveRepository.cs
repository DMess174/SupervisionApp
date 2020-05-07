using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class SheetGateValveRepository : RepositoryWithJournal<SheetGateValve, SheetGateValveJournal, SheetGateValveTCP>
    {
        public SheetGateValveRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CoatingTCP>> GetCoatingTCPsAsync()
        {
            await db.CoatingTCPs.LoadAsync();
            return db.CoatingTCPs.Local.ToObservableCollection();
        }

        public override async Task<IList<SheetGateValve>> GetAllAsync()
        {
            await db.SheetGateValves.LoadAsync();
            var result = db.SheetGateValves.Local.ToObservableCollection();
            return result;
        }

        public async Task<SheetGateValve> GetByIdIncludeAsync(int id)
        {
            var result = await db.SheetGateValves
                .Include(i => i.PID)
                    .ThenInclude(i => i.Specification)
                .Include(i => i.WeldGateValveCase)
                .Include(i => i.WeldGateValveCover)
                    .ThenInclude(i => i.Spindle)
                .Include(i => i.WeldGateValveCover)
                    .ThenInclude(i => i.RunningSleeve)
                .Include(i => i.Saddles)
                .Include(i => i.Gate)
                .Include(i => i.BallValves)
                .Include(i => i.ShearPins)
                .Include(i => i.CounterFlanges)
                .Include(i => i.BaseValveWithScrewNuts)
                .Include(i => i.BaseValveWithScrewStuds)
                .Include(i => i.BaseValveWithSprings)
                .Include(i => i.BaseValveWithSeals)
                .Include(i => i.BaseValveWithCoatings)
                    .ThenInclude(i => i.BaseAnticorrosiveCoating)
                .Include(i => i.SheetGateValveJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.SheetGateValveJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.CoatingJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.CoatingJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                    .Include(i => i.Files)
                    .ThenInclude(i => i.ElectronicDocument)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
