using DataLayer;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class ControlWeldRepository : RepositoryWithJournal<ControlWeld, ControlWeldJournal, ControlWeldTCP>
    {
        public ControlWeldRepository(DataContext context) : base(context) { }

        public async Task<ControlWeld> GetByIdIncludeAsync(int id)
        {
            return await db.ControlWelds.Include(i => i.ControlWeldJournals).SingleOrDefaultAsync(i => i.Id == id);
        }
    }
}
