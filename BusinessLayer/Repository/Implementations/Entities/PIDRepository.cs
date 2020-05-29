using BusinessLayer.Repository.Interfaces.Entities;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class PIDRepository : RepositoryWithJournal<PID, PIDJournal, PIDTCP>, IPIDRepository
    {
        public PIDRepository(DataContext context) : base(context) { }

        public async Task<bool> IsAmountRemaining(BaseAssemblyUnit unit)
        {
            using (DataContext context = new DataContext())
            {
                var item = await context.PIDs.Include(i => i.BaseAssemblyUnits).SingleOrDefaultAsync(i => i.Id == unit.PID.Id);
                if (item.Amount > item.BaseAssemblyUnits.Count || CheckAssemblyUnitIntoPID(item, unit.Id))
                    return true;
                else
                {
                    MessageBox.Show($"Из {item.Amount} шт. к PID привязано\n{item.BaseAssemblyUnits.Count} ед. продукции", "Ошибка");
                    return false;
                }
            }
        }

        //public async Task<IEnumerable<PID>> GetNonChecked()
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        var result = await context.PIDs
        //            .Include(i => i.Specification)
        //            .Include(i => i.PIDJournals).Where(i => i.PIDJournals)
        //    }
        //}
        //TODO: реализовать выборку PIDов

        public bool CheckAssemblyUnitIntoPID(PID pid, int id)
        {
            foreach (var i in pid.BaseAssemblyUnits)
            {
                if (i.Id == id) return true;
            }
            return false;
        }

        public async Task<PID> GetByIdIncludeAsync(int id)
        {
            return await db.PIDs.Include(i => i.PIDJournals)
                .Include(i => i.BaseAssemblyUnits)
                .Include(i => i.Specification)
                .ThenInclude(i => i.Customer)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public override async Task<IList<PID>> GetAllAsync()
        {
            await db.PIDs.Include(i => i.Specification).LoadAsync();
            return db.PIDs.Local.ToObservableCollection();
        }

        public void SetShippedProductAsync(PID pid)
        {
            pid.AmountShipped = pid.BaseAssemblyUnits.Where(i => i.Status == "Отгружен").Count();
        }
    }
}
