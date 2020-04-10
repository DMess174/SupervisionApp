using BusinessLayer.Repository.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class SaddleWithSealingRepository : Repository<SaddleWithSealing>, ISaddleWithSealingRepository
    {
        public SaddleWithSealingRepository(DataContext context) : base(context)
        {
        }
        /// <summary>
        /// Привязывает торцевое уплотнение к седлу
        /// </summary>
        /// <param name="saddle">Седло</param>
        /// <param name="sealing">Торцевое уплотнение</param>
        /// <returns></returns>
        public async Task<SaddleWithSealing> AddSealToSaddleAsync(Saddle saddle, FrontalSaddleSealing sealing)
        {
            if (saddle != null && sealing != null)
            {
                var newRecord = new SaddleWithSealing()
                {
                    SaddleId = saddle.Id,
                    Saddle = saddle,
                    FrontalSaddleSealingId = sealing.Id,
                    FrontalSaddleSealing = sealing,
                };
                var item = await AddAsync(newRecord);
                return item;
            }
            else return null;
        }
    }
}
