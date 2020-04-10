using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CastGateValveCaseRepository : RepositoryWithJournal<CastGateValveCase, CastGateValveCaseJournal, CastGateValveCaseTCP>
    {
        public CastGateValveCaseRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(CastGateValve valve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CastGateValveCases.Include(i => i.CastGateValve).SingleOrDefaultAsync(i => i.Id == valve.CastGateValveCase.Id);
                if (detail?.CastGateValve != null && detail.CastGateValve.Id != valve.Id)
                {
                    MessageBox.Show($"Корпус применен в {detail.CastGateValve.Name} № {detail.CastGateValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<CastGateValveCase>> GetAllAsync()
        {
            await db.CastGateValveCases.LoadAsync();
            var result = db.CastGateValveCases.Local.ToObservableCollection();
            return result;
        }

        public async Task<CastGateValveCase> GetByIdIncludeAsync(int id)
        {
            var result = await db.CastGateValveCases
                .Include(i => i.CastGateValve)
                .Include(i => i.Nozzles)
                .Include(i => i.CastGateValveCaseJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.CastGateValveCaseJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
