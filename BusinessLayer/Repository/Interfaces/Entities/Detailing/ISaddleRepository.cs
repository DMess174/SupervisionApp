using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces.Entities.Detailing
{
    public interface ISaddleRepository : IRepositoryWithJournal<Saddle, SaddleJournal, SaddleTCP>
    {
        Task<Saddle> GetByIdIncludeAsync(int id);
    }
}
