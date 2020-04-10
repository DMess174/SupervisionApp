using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class ShearPinRepository : RepositoryWithJournal<ShearPin, ShearPinJournal, ShearPinTCP>
    {
        public ShearPinRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsAssembliedAsync(ShearPin pin)
        {
            using (DataContext context = new DataContext())
            {
                var detail = await context.ShearPins.Include(i => i.BaseValve).SingleOrDefaultAsync(i => i.Id == pin.Id);
                if (detail?.BaseValve != null)
                {
                    MessageBox.Show($"Штифт применен в {detail.BaseValve.Name} № {detail.BaseValve.Number}", "Ошибка");
                    return true;
                }
                else return false;
            }
        }

        public override async Task<IList<ShearPin>> GetAllAsync()
        {
            await db.ShearPins.LoadAsync();
            var result = db.ShearPins.Local.ToObservableCollection();
            return result;
        }

        public async Task Load()
        {
            await db.ShearPins.LoadAsync();
        }

        public IList<ShearPin> UpdateList()
        {
            return db.ShearPins.Local.Where(i => i.BaseValveId == null).ToList();
        }

        public async Task<ShearPin> GetByIdIncludeAsync(int id)
        {
            var result = await db.ShearPins
                .Include(i => i.BaseValve)
                .Include(i => i.ShearPinJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
