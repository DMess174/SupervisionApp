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
    public class SideWallRepository : RepositoryWithJournal<SideWall, SideWallJournal, SideWallTCP>
    {
        public SideWallRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(SideWall wall)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.SideWalls.Include(i => i.WeldGateValveCase).SingleOrDefaultAsync(i => i.Id == wall.Id);
                if (detail?.WeldGateValveCase != null)
                {
                    MessageBox.Show($"Стенка применена в {detail.WeldGateValveCase.Name} № {detail.WeldGateValveCase.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public async Task Load()
        {
            await db.SideWalls.LoadAsync();
        }

        public IList<SideWall> UpdateList()
        {
            return db.SideWalls.Local.Where(i => i.WeldGateValveCaseId == null).ToList();
        }

        public override async Task<IList<SideWall>> GetAllAsync()
        {
            await db.SideWalls.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.SideWalls.Local.ToObservableCollection();
            return result;
        }

        public async Task<SideWall> GetByIdIncludeAsync(int id)
        {
            var result = await db.SideWalls
                .Include(i => i.WeldGateValveCase)
                .Include(i => i.SideWallJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
