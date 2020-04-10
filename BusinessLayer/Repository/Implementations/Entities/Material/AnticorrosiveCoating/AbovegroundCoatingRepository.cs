using DataLayer;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class AbovegroundCoatingRepository : RepositoryWithJournal<AbovegroundCoating, AbovegroundCoatingJournal, AnticorrosiveCoatingTCP>
    {
        public AbovegroundCoatingRepository(DataContext context) : base(context) { }

        public async Task<AbovegroundCoating> GetByIdIncludeAsync(int id)
        {
            return await db.AbovegroundCoatings.Include(i => i.AbovegroundCoatingJournals)
                .Include(i => i.BaseValveWithCoatings).ThenInclude(i => i.BaseValve)
                .Include(i => i.ReverseShutterWithCoatings).ThenInclude(i => i.ReverseShutter)
                .SingleOrDefaultAsync(i => i.Id == id);
        }
    }
}
