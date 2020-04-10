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
    public class SpringRepository : RepositoryWithJournal<Spring, SpringJournal, SpringTCP>
    {
        public SpringRepository(DataContext context) : base(context)
        {
        }

        /// <summary>
        /// Возвращает true, если остаток больше "0".
        /// </summary>
        /// <param name="spring">Партия пружин</param>
        /// <param name="amount">Запрашиваемое количество</param>
        /// <returns></returns>
        public async Task<bool> IsAmountRemaining(Spring spring, int amount)
        {
            using (DataContext context = new DataContext())
            {
                var amountRemaining = await GetAmountRemaining(spring);
                if (amountRemaining >= amount) 
                    return true;
                else
                {
                    MessageBox.Show($"Остаток пружин {spring.Number} составляет {amountRemaining} шт.", "Ошибка");
                    return false;
                }
            }
        }

        public async Task<int> GetAmountRemaining(Spring spring)
        {
            using (DataContext context = new DataContext())
            {
                var item = await context.Springs.Include(i => i.BaseValveWithSprings).SingleOrDefaultAsync(i => i.Id == spring.Id);
                int amountUsed = 0;
                foreach (var i in item.BaseValveWithSprings)
                {
                    amountUsed += i.SpringAmount;
                }
                return item.Amount - amountUsed;
            }
        }

        public IList<Spring> UpdateList()
        {
            return db.Springs.Local.Where(i => i.AmountRemaining > 0).ToList();
        }

        public async Task<Spring> GetByIdIncludeAsync(int id)
        {
            var result = await db.Springs
                .Include(i => i.BaseValveWithSprings)
                    .ThenInclude(i => i.BaseValve)
                .Include(i => i.SpringJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
