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
    public class FrontalSaddleSealingRepository : RepositoryWithJournal<FrontalSaddleSealing, FrontalSaddleSealingJournal, FrontalSaddleSealingTCP>, IFrontalSaddleSealingRepository
    {
        public FrontalSaddleSealingRepository(DataContext context) : base(context)
        {
        }

        /// <summary>
        /// Возвращает true, если остаток больше "0".
        /// </summary>
        /// <param name="sealing"></param>
        /// <returns></returns>
        public async Task<bool> IsAmountRemaining(FrontalSaddleSealing sealing)
        {
            using (DataContext context = new DataContext())
            {
                var item = await context.FrontalSaddleSeals.Include(i => i.SaddleWithSealings).SingleOrDefaultAsync(i => i.Id == sealing.Id);
                if (item.Amount > item.SaddleWithSealings.Count) 
                    return true;
                else
                {
                    MessageBox.Show("Уплотнения данной партии закончились", "Ошибка");
                    return false;
                }
            }
        }

        public IList<FrontalSaddleSealing> UpdateList()
        {
            return db.FrontalSaddleSeals.Local.Where(i => i.AmountRemaining > 0).ToList();
        }

        public async Task<FrontalSaddleSealing> GetByIdIncludeAsync(int id)
        {
            var result = await db.FrontalSaddleSeals
                .Include(i => i.SaddleWithSealings)
                    .ThenInclude(i => i.Saddle)
                .Include(i => i.FrontalSaddleSealingJournals)
                    .ThenInclude(i => i.EntityTCP)
                    .ThenInclude(i => i.ProductType)
                .SingleOrDefaultAsync(i => i.Id == id);
            return result;
        }
    }
}
