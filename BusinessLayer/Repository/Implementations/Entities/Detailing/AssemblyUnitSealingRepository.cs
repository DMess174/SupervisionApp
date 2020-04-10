using BusinessLayer.Repository.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class AssemblyUnitSealingRepository : RepositoryWithJournal<AssemblyUnitSealing, AssemblyUnitSealingJournal, AssemblyUnitSealingTCP>
    {
        public AssemblyUnitSealingRepository(DataContext context) : base(context)
        {
        }

        /// <summary>
        /// Возвращает true, если остаток больше "0".
        /// </summary>
        /// <param name="sealing"></param>
        /// <returns></returns>
        public async Task<bool> IsAmountRemaining(AssemblyUnitSealing sealing)
        {
            using (DataContext context = new DataContext())
            {
                var item = await context.AssemblyUnitSeals.Include(i => i.BaseValveWithSeals).SingleOrDefaultAsync(i => i.Id == sealing.Id);
                if (item.Amount > item.BaseValveWithSeals.Count) 
                    return true;
                else
                {
                    MessageBox.Show("Уплотнения данной партии закончились", "Ошибка");
                    return false;
                }
            }
        }

        public IList<AssemblyUnitSealing> UpdateList()
        {
            return db.AssemblyUnitSeals.Local.Where(i => i.AmountRemaining > 0).ToList();
        }

        public async Task<AssemblyUnitSealing> GetByIdIncludeAsync(int id)
        {
            var result = await db.AssemblyUnitSeals
                .Include(i => i.BaseValveWithSeals)
                    .ThenInclude(i => i.BaseValve)
                .Include(i => i.AssemblyUnitSealingJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
