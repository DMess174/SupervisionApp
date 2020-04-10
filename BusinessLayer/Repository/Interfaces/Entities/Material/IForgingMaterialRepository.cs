using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces.Entities.Material
{
    public interface IForgingMaterialRepository : IRepository<ForgingMaterial>, IRepositoryWithJournal<ForgingMaterial, ForgingMaterialJournal, MetalMaterialTCP>
    {
        Task<ForgingMaterial> GetByIdIncludeAsync(int id);
    }
}
