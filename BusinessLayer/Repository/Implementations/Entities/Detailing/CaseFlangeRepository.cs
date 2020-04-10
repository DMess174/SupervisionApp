using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CaseFlangeRepository : RepositoryWithJournal<CaseFlange, CaseFlangeJournal, CaseFlangeTCP>
    {
        public CaseFlangeRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(WeldGateValveCase weldCase)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CaseFlanges.Include(i => i.WeldGateValveCase).SingleOrDefaultAsync(i => i.Id == weldCase.CaseFlange.Id);
                if (detail?.WeldGateValveCase != null && detail.WeldGateValveCase.Id != weldCase.Id)
                {
                    MessageBox.Show($"Фланец применен в {detail.WeldGateValveCase.Name} № {detail.WeldGateValveCase.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<CaseFlange>> GetAllAsync()
        {
            await db.CaseFlanges.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.CaseFlanges.Local.ToObservableCollection();
            return result;
        }

        public async Task<CaseFlange> GetByIdIncludeAsync(int id)
        {
            var result = await db.CaseFlanges
                .Include(i => i.WeldGateValveCase)
                .Include(i => i.CaseFlangeJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
