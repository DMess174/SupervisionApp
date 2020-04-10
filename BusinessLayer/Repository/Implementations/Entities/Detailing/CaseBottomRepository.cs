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
    public class CaseBottomRepository : RepositoryWithJournal<CaseBottom, CaseBottomJournal, CaseBottomTCP>
    {
        public CaseBottomRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(WeldGateValveCase weldCase)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CaseBottoms.Include(i => i.WeldGateValveCase).SingleOrDefaultAsync(i => i.Id == weldCase.CaseBottom.Id);
                if (detail?.WeldGateValveCase != null && detail.WeldGateValveCase.Id != weldCase.Id)
                {
                    MessageBox.Show($"Днище применено в {detail.WeldGateValveCase.Name} № {detail.WeldGateValveCase.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }



        public override async Task<IList<CaseBottom>> GetAllAsync()
        {
            await db.CaseBottoms.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.CaseBottoms.Local.ToObservableCollection();
            return result;
        }

        public async Task<CaseBottom> GetByIdIncludeAsync(int id)
        {
            var result = await db.CaseBottoms
                .Include(i => i.WeldGateValveCase)
                .Include(i => i.CaseBottomJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
