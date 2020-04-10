using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class FrontWallRepository : RepositoryWithJournal<FrontWall, FrontWallJournal, FrontWallTCP>
    {
        public FrontWallRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(FrontWall wall)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.FrontWalls.Include(i => i.WeldGateValveCase).SingleOrDefaultAsync(i => i.Id == wall.Id);
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
            await db.FrontWalls.LoadAsync();
        }

        public IList<FrontWall> UpdateList()
        {
            return db.FrontWalls.Local.Where(i => i.WeldGateValveCaseId == null).ToList();
        }

        public override async Task<IList<FrontWall>> GetAllAsync()
        {
            await db.FrontWalls.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.FrontWalls.Local.ToObservableCollection();
            return result;
        }

        public async Task<FrontWall> GetByIdIncludeAsync(int id)
        {
            var result = await db.FrontWalls
                .Include(i => i.WeldGateValveCase)
                .Include(i => i.FrontWallJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .Include(i => i.WeldNozzle)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
