using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class ReverseShutterCaseRepository : RepositoryWithJournal<ReverseShutterCase, ReverseShutterCaseJournal, ReverseShutterCaseTCP>
    {
        public ReverseShutterCaseRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(ReverseShutter shutter)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.ReverseShutterCases.Include(i => i.ReverseShutter).SingleOrDefaultAsync(i => i.Id == shutter.ReverseShutterCase.Id);
                if (detail?.ReverseShutter != null && detail.ReverseShutter.Id != shutter.Id)
                {
                    MessageBox.Show($"Корпус применен в {detail.ReverseShutter.Name} № {detail.ReverseShutter.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<ReverseShutterCase>> GetAllAsync()
        {
            await db.ReverseShutterCases.LoadAsync();
            var result = db.ReverseShutterCases.Local.ToObservableCollection();
            return result;
        }

        public async Task<ReverseShutterCase> GetByIdIncludeAsync(int id)
        {
            var result = await db.ReverseShutterCases
                .Include(i => i.ReverseShutter)
                .Include(i => i.Nozzles)
                .Include(i => i.ReverseShutterCaseJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.ReverseShutterCaseJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
