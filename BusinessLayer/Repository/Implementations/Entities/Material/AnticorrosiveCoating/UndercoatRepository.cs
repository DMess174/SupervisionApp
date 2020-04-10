using DataLayer;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class UndercoatRepository : RepositoryWithJournal<Undercoat, UndercoatJournal, AnticorrosiveCoatingTCP>
    {
        public UndercoatRepository(DataContext context) : base(context) { }

        public async Task<Undercoat> GetByIdIncludeAsync(int id)
        {
            return await db.Undercoats.Include(i => i.UndercoatJournals)
                .Include(i => i.BaseValveWithCoatings).ThenInclude(i => i.BaseValve)
                .Include(i => i.ReverseShutterWithCoatings).ThenInclude(i => i.ReverseShutter)
                .SingleOrDefaultAsync(i => i.Id == id);
        }
    }
}
