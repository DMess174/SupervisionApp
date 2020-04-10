using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces.Entities.Detailing
{
    public interface IFrontalSaddleSealingRepository : IRepositoryWithJournal<FrontalSaddleSealing, FrontalSaddleSealingJournal, FrontalSaddleSealingTCP>
    {
        Task<FrontalSaddleSealing> GetByIdIncludeAsync(int id);
    }
}
