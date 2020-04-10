using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CastGateValveRepository : RepositoryWithJournal<CastGateValve, CastGateValveJournal, CastGateValveTCP>
    {
        public CastGateValveRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CoatingTCP>> GetCoatingTCPsAsync()
        {
            await db.CoatingTCPs.LoadAsync();
            return db.CoatingTCPs.Local.ToObservableCollection();
        }

        public override async Task<IList<CastGateValve>> GetAllAsync()
        {
            await db.CastGateValves.LoadAsync();
            var result = db.CastGateValves.Local.ToObservableCollection();
            return result;
        }

        public async Task<CastGateValve> GetByIdIncludeAsync(int id)
        {
            var result = await db.CastGateValves
                .Include(i => i.PID)
                    .ThenInclude(i => i.Specification)
                .Include(i => i.CastGateValveCase)
                    .ThenInclude(i => i.Nozzles)
                .Include(i => i.CastGateValveCover)
                    .ThenInclude(i => i.CoverSealingRing)
                .Include(i => i.CastGateValveCover)
                    .ThenInclude(i => i.Spindle)
                .Include(i => i.CastGateValveCover)
                    .ThenInclude(i => i.RunningSleeve)
                .Include(i => i.Saddles)
                .Include(i => i.Gate)
                .Include(i => i.BallValves)
                .Include(i => i.ShearPins)
                .Include(i => i.BaseValveWithScrewNuts)
                .Include(i => i.BaseValveWithScrewStuds)
                .Include(i => i.BaseValveWithSprings)
                .Include(i => i.BaseValveWithSeals)
                .Include(i => i.BaseValveWithCoatings)
                    .ThenInclude(i => i.BaseAnticorrosiveCoating)
                .Include(i => i.CastGateValveJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.CastGateValveJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.CoatingJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.CoatingJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
