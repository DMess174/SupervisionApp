using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BusinessLayer.Repository.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class NozzleRepository : RepositoryWithJournal<Nozzle, NozzleJournal, NozzleTCP>, INozzleRepository
    {
        public NozzleRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(Nozzle nozzle)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.Nozzles.Include(i => i.CastingCase).SingleOrDefaultAsync(i => i.Id == nozzle.Id);
                if (detail?.CastingCase != null)
                {
                    MessageBox.Show($"Катушка применена в {detail.CastingCase.Name} № {detail.CastingCase.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public async Task Load()
        {
            await db.Nozzles.LoadAsync();
        }

        public IList<Nozzle> UpdateList()
        {
            return db.Nozzles.Local.Where(i => i.CastingCaseId == null).ToList();
        }

        public override async Task<IList<Nozzle>> GetAllAsync()
        {
            await db.Nozzles.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.Nozzles.Local.ToObservableCollection();
            return result;
        }

        public async Task<Nozzle> GetByIdIncludeAsync(int id)
        {
            var result = await db.Nozzles
                .Include(i => i.CastingCase)
                .Include(i => i.NozzleJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
