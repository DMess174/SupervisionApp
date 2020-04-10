using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CompactGateValveCaseRepository : RepositoryWithJournal<CompactGateValveCase, CompactGateValveCaseJournal, CompactGateValveCaseTCP>
    {
        public CompactGateValveCaseRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(CompactGateValve valve)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CompactGateValveCases.Include(i => i.BaseWeldValve).SingleOrDefaultAsync(i => i.Id == valve.WeldGateValveCase.Id);
                if (detail?.BaseWeldValve != null && detail.BaseWeldValve.Id != valve.Id)
                {
                    MessageBox.Show($"Корпус применен в {detail.BaseWeldValve.Name} № {detail.BaseWeldValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<CompactGateValveCase>> GetAllAsync()
        {
            await db.CompactGateValveCases.LoadAsync();
            var result = db.CompactGateValveCases.Local.ToObservableCollection();
            return result;
        }

        public async Task<CompactGateValveCase> GetByIdIncludeAsync(int id)
        {
            var result = await db.CompactGateValveCases
                .Include(i => i.BaseWeldValve)
                .Include(i => i.FrontWalls)
                    .ThenInclude(i => i.WeldNozzle)
                .Include(i => i.SideWalls)
                .Include(i => i.CaseEdges)
                .Include(i => i.CaseFlange)
                .Include(i => i.CaseBottom)
                .Include(i => i.CompactGateValveCaseJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.OperationType)
                .Include(i => i.CompactGateValveCaseJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
