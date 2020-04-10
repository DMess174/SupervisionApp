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
    public class ScrewNutRepository : RepositoryWithJournal<ScrewNut, ScrewNutJournal, ScrewNutTCP>
    {
        public ScrewNutRepository(DataContext context) : base(context)
        {
        }

        /// <summary>
        /// Возвращает true, если остаток больше "0".
        /// </summary>
        /// <param name="screwNut">Партия гаек</param>
        /// <param name="amount">Запрашиваемое количество</param>
        /// <returns></returns>
        public async Task<bool> IsAmountRemaining(ScrewNut screwNut, int amount)
        {
            using (DataContext context = new DataContext())
            {
                var amountRemaining = await GetAmountRemaining(screwNut);
                if (amountRemaining >= amount) 
                    return true;
                else
                {
                    MessageBox.Show($"Остаток гаек {screwNut.Number} составляет {amountRemaining} шт.", "Ошибка");
                    return false;
                }
            }
        }

        public async Task<int> GetAmountRemaining(ScrewNut screwNut)
        {
            using (DataContext context = new DataContext())
            {
                var item = await context.ScrewNuts.Include(i => i.BaseValveWithScrewNuts).SingleOrDefaultAsync(i => i.Id == screwNut.Id);
                int amountUsed = 0;
                foreach (var i in item.BaseValveWithScrewNuts)
                {
                    amountUsed += i.ScrewNutAmount;
                }
                return item.Amount - amountUsed;
            }
        }

        public IList<ScrewNut> UpdateList()
        {
            return db.ScrewNuts.Local.Where(i => i.AmountRemaining > 0).ToList();
        }

        public async Task<ScrewNut> GetByIdIncludeAsync(int id)
        {
            var result = await db.ScrewNuts
                .Include(i => i.BaseValveWithScrewNuts)
                    .ThenInclude(i => i.BaseValve)
                .Include(i => i.ScrewNutJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
