using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class GateRepository : RepositoryWithJournal<Gate, GateJournal, GateTCP>
    {
        public GateRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(BaseValve valve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.Gates.Include(i => i.BaseValve).SingleOrDefaultAsync(i => i.Id == valve.Gate.Id);
                if (detail?.BaseValve != null && detail.BaseValve.Id != valve.Id)
                {
                    MessageBox.Show($"Шибер применен в {detail.BaseValve.Name} № {detail.BaseValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }



        public override async Task<IList<Gate>> GetAllAsync()
        {
            await db.Gates.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.Gates.Local.ToObservableCollection();
            return result;
        }

        public async Task<Gate> GetByIdIncludeAsync(int id)
        {
            var result = await db.Gates
                .Include(i => i.BaseValve)
                .Include(i => i.PID)
                    .ThenInclude(i => i.Specification)
                .Include(i => i.GateJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.GateJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
