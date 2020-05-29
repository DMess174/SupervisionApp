using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CompactGateValveRepository : RepositoryWithJournal<CompactGateValve, CompactGateValveJournal, CompactGateValveTCP>
    {
        public CompactGateValveRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CoatingTCP>> GetCoatingTCPsAsync()
        {
            await db.CoatingTCPs.LoadAsync();
            return db.CoatingTCPs.Local.ToObservableCollection();
        }

        public override async Task<IList<CompactGateValve>> GetAllAsync()
        {
            await db.CompactGateValves.LoadAsync();
            var result = db.CompactGateValves.Local.ToObservableCollection();
            return result;
        }

        public async Task<CompactGateValve> GetByIdIncludeAsync(int id)
        {
            var result = await db.CompactGateValves
                .Include(i => i.PID)
                    .ThenInclude(i => i.Specification)
                .Include(i => i.WeldGateValveCase)
                .Include(i => i.WeldGateValveCover)
                    .ThenInclude(i => i.Spindle)
                .Include(i => i.WeldGateValveCover)
                    .ThenInclude(i => i.RunningSleeve)
                .Include(i => i.Saddles)
                .Include(i => i.Shutter)
                .Include(i => i.BallValves)
                .Include(i => i.ShearPins)
                .Include(i => i.CounterFlanges)
                .Include(i => i.BaseValveWithScrewNuts)
                .Include(i => i.BaseValveWithScrewStuds)
                .Include(i => i.BaseValveWithSeals)
                .Include(i => i.BaseValveWithCoatings)
                    .ThenInclude(i => i.BaseAnticorrosiveCoating)
                .Include(i => i.CompactGateValveJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.CompactGateValveJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.CoatingJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.CoatingJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                //.Include(i => i.Files)
                //    .ThenInclude(i => i.ElectronicDocument)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
