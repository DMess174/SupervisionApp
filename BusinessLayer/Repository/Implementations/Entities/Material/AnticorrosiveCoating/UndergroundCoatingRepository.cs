using DataLayer;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class UndergroundCoatingRepository : RepositoryWithJournal<UndergroundCoating, UndergroundCoatingJournal, AnticorrosiveCoatingTCP>
    {
        public UndergroundCoatingRepository(DataContext context) : base(context) { }

        public async Task<UndergroundCoating> GetByIdIncludeAsync(int id)
        {
            return await db.UndergroundCoatings.Include(i => i.UndergroundCoatingJournals)
                .Include(i => i.BaseValveWithCoatings).ThenInclude(i => i.BaseValve)
                .Include(i => i.ReverseShutterWithCoatings).ThenInclude(i => i.ReverseShutter)
                .SingleOrDefaultAsync(i => i.Id == id);
        }
    }
}
