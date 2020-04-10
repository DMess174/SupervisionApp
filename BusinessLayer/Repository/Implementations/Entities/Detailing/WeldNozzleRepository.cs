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
    public class WeldNozzleRepository : RepositoryWithJournal<WeldNozzle, WeldNozzleJournal, WeldNozzleTCP>
    {
        public WeldNozzleRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsNozzleAssembliedAsync(FrontWall wall)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.WeldNozzles.Include(i => i.FrontWall).SingleOrDefaultAsync(i => i.Id == wall.WeldNozzle.Id);
                if (detail?.FrontWall != null && detail.FrontWall.Id != wall.Id)
                {
                    MessageBox.Show($"Патрубок применен в {detail.FrontWall.Name} № {detail.FrontWall.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<WeldNozzle>> GetAllAsync()
        {
            await db.WeldNozzles.Include(i => i.MetalMaterial).LoadAsync();
            var result = db.WeldNozzles.Local.ToObservableCollection();
            return result;
        }

        public async Task<WeldNozzle> GetByIdIncludeAsync(int id)
        {
            var result = await db.WeldNozzles
                .Include(i => i.FrontWall)
                .Include(i => i.WeldNozzleJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .Include(i => i.MetalMaterial)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
