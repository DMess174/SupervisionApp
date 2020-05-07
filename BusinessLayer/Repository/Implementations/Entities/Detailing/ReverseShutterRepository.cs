using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class ReverseShutterRepository : RepositoryWithJournal<ReverseShutter, ReverseShutterJournal, ReverseShutterTCP>
    {
        public ReverseShutterRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CoatingTCP>> GetCoatingTCPsAsync()
        {
            await db.CoatingTCPs.LoadAsync();
            return db.CoatingTCPs.Local.ToObservableCollection();
        }

        public override async Task<IList<ReverseShutter>> GetAllAsync()
        {
            await db.ReverseShutters.LoadAsync();
            var result = db.ReverseShutters.Local.ToObservableCollection();
            return result;
        }

        public async Task<ReverseShutter> GetByIdIncludeAsync(int id)
        {
            var result = await db.ReverseShutters
                .Include(i => i.PID)
                    .ThenInclude(i => i.Specification)
                .Include(i => i.ReverseShutterCase)
                .Include(i => i.SlamShutter)
                .Include(i => i.ShaftShutter)
                .Include(i => i.BronzeSleeveShutters)
                .Include(i => i.SteelSleeveShutters)
                .Include(i => i.StubShutters)
                .Include(i => i.ReverseShutterWithCoatings)
                    .ThenInclude(i => i.BaseAnticorrosiveCoating)
                .Include(i => i.ReverseShutterJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.ReverseShutterJournals)
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
