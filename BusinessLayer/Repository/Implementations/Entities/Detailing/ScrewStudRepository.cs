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
    public class ScrewStudRepository : RepositoryWithJournal<ScrewStud, ScrewStudJournal, ScrewStudTCP>
    {
        public ScrewStudRepository(DataContext context) : base(context)
        {
        }

        /// <summary>
        /// Возвращает true, если остаток больше "0".
        /// </summary>
        /// <param name="screwStud">Партия шпилек</param>
        /// <param name="amount">Запрашиваемое количество</param>
        /// <returns></returns>
        public async Task<bool> IsAmountRemaining(ScrewStud screwStud, int amount)
        {
            using (DataContext context = new DataContext())
            {
                var amountRemaining = await GetAmountRemaining(screwStud);
                if (amountRemaining >= amount) 
                    return true;
                else
                {
                    MessageBox.Show($"Остаток шпилек {screwStud.Number} составляет {amountRemaining} шт.", "Ошибка");
                    return false;
                }
            }
        }

        public async Task<int> GetAmountRemaining(ScrewStud screwStud)
        {
            using (DataContext context = new DataContext())
            {
                var item = await context.ScrewStuds.Include(i => i.BaseValveWithScrewStuds).SingleOrDefaultAsync(i => i.Id == screwStud.Id);
                int amountUsed = 0;
                foreach (var i in item.BaseValveWithScrewStuds)
                {
                    amountUsed += i.ScrewStudAmount;
                }
                return item.Amount - amountUsed;
            }
        }

        public IList<ScrewStud> UpdateList()
        {
            return db.ScrewStuds.Local.Where(i => i.AmountRemaining > 0).ToList();
        }

        public async Task<ScrewStud> GetByIdIncludeAsync(int id)
        {
            var result = await db.ScrewStuds
                .Include(i => i.BaseValveWithScrewStuds)
                    .ThenInclude(i => i.BaseValve)
                .Include(i => i.ScrewStudJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
