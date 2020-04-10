using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class CaseEdgeRepository : RepositoryWithJournal<CaseEdge, CaseEdgeJournal, CaseEdgeTCP>
    {
        public CaseEdgeRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(CaseEdge edge)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.CaseEdges.Include(i => i.WeldGateValveCase).SingleOrDefaultAsync(i => i.Id == edge.Id);
                if (detail?.WeldGateValveCase != null)
                {
                    MessageBox.Show($"Ребро применено в {detail.WeldGateValveCase.Name} № {detail.WeldGateValveCase.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<CaseEdge>> GetAllAsync()
        {
            await db.CaseEdges.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.CaseEdges.Local.ToObservableCollection();
            return result;
        }

        public async Task Load()
        {
            await db.CaseEdges.LoadAsync();
        }

        public IList<CaseEdge> UpdateList()
        {
            return db.CaseEdges.Local.Where(i => i.WeldGateValveCaseId == null).ToList();
        }

        public async Task<CaseEdge> GetByIdIncludeAsync(int id)
        {
            var result = await db.CaseEdges
                .Include(i => i.WeldGateValveCase)
                .Include(i => i.CaseEdgeJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
